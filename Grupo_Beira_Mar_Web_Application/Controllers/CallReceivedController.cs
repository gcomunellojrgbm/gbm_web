using Grupo_Beira_Mar_Web_Application.Data;
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
            var client = await _dbContext.Cliente.FirstOrDefaultAsync(c => c.TelefoneContato.Equals(phoneNumber));

            if(client == null)
            {
                return BadRequest($"Número não cadastrado: {phoneNumber} ");
            }
            else
            {
                DateTime dtEvento = DateTime.MinValue
                    .AddYears(1969) // ano Linux começa em 1970
                    .AddMilliseconds(Double.Parse(date))    //soma os milisegundos informados
                    .AddHours(-3); // corrige para o fuso do BR

                // Verifica se Evento já foi registrado
                var evento = await (
                    from e in _dbContext.Evento
                    where e.Conta.Equals(client.Codigo)
                       && e.DataHora.Equals(dtEvento)
                    select e
                ).FirstOrDefaultAsync();

                if (evento == null)
                {
                    Evento novoEvento = new Evento();

                    novoEvento.Conta = client.Codigo;
                    novoEvento.DataHora = dtEvento;
                    novoEvento.Evento1 = "702";
                    novoEvento.EvtRest = 1;
                    novoEvento.Grupo = "00";
                    novoEvento.IdFormato = 1;
                    novoEvento.IdReceptora = 1;
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

                return Ok($"Número registrado: {phoneNumber} ");
            }

            
        }

       
    }
}
