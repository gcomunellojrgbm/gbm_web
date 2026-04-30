using Grupo_Beira_Mar_Web_Application.Data;
using Grupo_Beira_Mar_Web_Application.Data.Migrations;
using Grupo_Beira_Mar_Web_Application.DataModels;
using Grupo_Beira_Mar_Web_Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Evento = Grupo_Beira_Mar_Web_Application.DataModels.Evento;

namespace Grupo_Beira_Mar_Web_Application.Controllers
{
    public class CallReceivedController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public CallReceivedController(
            ILogger<HomeController> logger,
            ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> Index(String phoneNumber, String date)
        {
            var client = await _dbContext.Cliente.FirstOrDefaultAsync(c => c.TelefoneContato.Equals(phoneNumber) && c.IdReceptora.Equals(1));

            if(client == null)
            {
                return BadRequest($"Número {phoneNumber} não cadastrado para GSM.");
            }
            else
            {
                DateTime dtEvento = DateTime.MinValue
                    .AddYears(1969) // ano Linux começa em 1970
                    .AddMilliseconds(Double.Parse(date))    //soma os milisegundos informados
                    .AddHours(-3); // corrige para o fuso do BR
                var Evento = "R130";
                var idReceptora = 1;

                await CriarEvento(client, dtEvento, Evento, idReceptora);

                return Ok($"Número registrado: {phoneNumber} ");
            }


        }

        private async Task CriarEvento(Cliente client, DateTime dtEvento, string Evento, int IdReceptora)
        {
            // Verifica se Evento já foi registrado
            var evento = await (
                from e in _dbContext.Evento
                where e.IdCliente.Equals(client.IdCliente)
                   && e.DataHora.Equals(dtEvento)
                   && e.Evento1.Equals(Evento)
                select e
            ).FirstOrDefaultAsync();

            if (evento == null)
            {
                Evento novoEvento = new Evento();

                novoEvento.Conta = client.Codigo;
                novoEvento.IdCliente = client.IdCliente;
                novoEvento.DataHora = dtEvento;
                novoEvento.Evento1 = Evento;
                novoEvento.EvtRest = 1;
                novoEvento.Grupo = "00";
                novoEvento.IdFormato = 1;
                novoEvento.IdReceptora = IdReceptora;
                novoEvento.QtdEventos = 1;
                novoEvento.Zona = "000";

                _dbContext.Evento.Add(novoEvento);
                await _dbContext.SaveChangesAsync();

                var eventoMonitoramento = new EventoMonitoramento();
                _dbContext.EventoMonitoramento.Add(eventoMonitoramento);

                eventoMonitoramento.IdEvento = novoEvento.IdEvento; // Vincula ao evento recém-salvo/atualizado
                eventoMonitoramento.IdUsuario = 1;
                eventoMonitoramento.Atendimento = false;
                eventoMonitoramento.Concluido = false;
                eventoMonitoramento.Ativo = false;
                eventoMonitoramento.DataHoraInicio = DateTime.UtcNow.AddHours(-3);
                eventoMonitoramento.DataHoraTermino = null;
                eventoMonitoramento.DescricaoMonitoramento = "";
                eventoMonitoramento.IdReceptora = novoEvento.IdReceptora;

                await _dbContext.SaveChangesAsync();

            }
        }

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> EventoReceptora(
            int idReceptora, 
            String codigoCliente,
            String particao,
            String evento
        )
        {
            try
            {
                //Busca Configurações do Evento na Receptora
                var configEvento = await (
                    from ReceptoraAcao in _dbContext.ReceptoraAcao
                    where ReceptoraAcao.IdReceptora == idReceptora
                    join EventoEstadoAcao in _dbContext.EventoEstadoAcao
                        on ReceptoraAcao.IdEventoEstadoAcao equals EventoEstadoAcao.Id
                    where EventoEstadoAcao.CodigoEvento == evento
                    join EventoEstado in _dbContext.EventoEstado
                        on EventoEstadoAcao.IdEventoEstado equals EventoEstado.Id
                    join Receptora in _dbContext.Receptora
                        on ReceptoraAcao.IdReceptora equals Receptora.IdReceptora
                    select new
                    {
                        ReceptoraAcao, EventoEstadoAcao, EventoEstado, Receptora
                    }
                    //where e.Conta.Equals(client.Codigo)
                    //   && e.DataHora.Equals(dtEvento)
                    //select e
                ).FirstOrDefaultAsync();

                if(configEvento == null)
                {
                    return BadRequest("Parâmetros Inválidos");
                }
                else
                {
                    //Registra o evento da Receptora


                    //Abre o atendimento
                    if (configEvento.ReceptoraAcao.GeraAtendimento)
                    {
                        var client = await _dbContext.Cliente.FirstOrDefaultAsync(c => c.IdReceptora.Equals(idReceptora) && c.Codigo.Equals(codigoCliente));

                        if (client == null)
                        {
                            return BadRequest($"Codigo Cliente {codigoCliente} não cadastrado na Recptora {configEvento.Receptora.Nome} ");
                        }
                        else
                        {
                            await CriarEvento(client, DateTime.Now, evento, idReceptora);
                        }
                    }
                }
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
