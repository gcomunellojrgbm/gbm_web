using Grupo_Beira_Mar_Web_Application.Data;
using Grupo_Beira_Mar_Web_Application.DataModels;
using Grupo_Beira_Mar_Web_Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Grupo_Beira_Mar_Web_Application.Controllers
{
    public class EventoController : Controller
    {
        private readonly ILogger<EventoController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public EventoController(
            ILogger<EventoController> logger,
            ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        // Action para exibir a lista de eventos
        public async Task<IActionResult> Index()
        {
            // Modificado para usar JOINs explícitos e um ViewModel específico para a listagem
            var eventos = await (from Evento in _dbContext.Evento
                                 join Cliente in _dbContext.Cliente
                                    on Evento.IdCliente equals Cliente.IdCliente //into cGroup
                                 join Receptora in _dbContext.Receptora
                                    on Cliente.IdReceptora equals Receptora.IdReceptora
                                 join EventoMonitoramento in _dbContext.EventoMonitoramento
                                    on Evento.IdEvento equals EventoMonitoramento.IdEvento //into emGroup

                                 join EventoEstadoAcao in _dbContext.EventoEstadoAcao
                                    on Evento.Evento1 equals EventoEstadoAcao.CodigoEvento
                                    into eventoEstadoAcaoGroup
                                 from EventoEstadoAcao in eventoEstadoAcaoGroup.DefaultIfEmpty()

                                 join ReceptoraAcao in _dbContext.ReceptoraAcao
                                    on new
                                    {
                                        IdReceptora = Receptora.IdReceptora,
                                        IdEventoEstadoAcao = (int?)EventoEstadoAcao.Id
                                    }
                                    equals new
                                    {
                                        IdReceptora = ReceptoraAcao.IdReceptora,
                                        IdEventoEstadoAcao = (int?)ReceptoraAcao.IdEventoEstadoAcao
                                    }
                                    into receptoraAcaoGroup
                                 from ReceptoraAcao in receptoraAcaoGroup.DefaultIfEmpty()

                                 orderby Evento.DataHora descending
                                 select new EventoIndexViewModel
                                 {
                                     IdEvento = Evento.IdEvento,
                                     ReceptoraNome = Receptora.Nome,
                                     NumeroEvento = Evento.IdEvento,
                                     Conta = Cliente.Codigo + (String.IsNullOrEmpty(Cliente.Particao) ? "" : $" - {Cliente.Particao}"),
                                     NomeCliente = Cliente.Nome, // Obtém o nome do cliente através do join
                                     IdCliente = Cliente.IdCliente, // Obtém o nome do cliente através do join
                                     DataEvento = Evento.DataHora,
                                     TipoEvento = EventoEstadoAcao != null ?
                                        $"{Evento.Evento1} - {EventoEstadoAcao.Decricao}" :
                                        Evento.Evento1,
                                     GeraAtendimento = ReceptoraAcao != null ? ReceptoraAcao.GeraAtendimento : false,
                                     DisparaSom = ReceptoraAcao != null ? ReceptoraAcao.DisparaSom : false
                                 })
                                 .Take(1000) // Limita para fins de demonstração e performance
                                 .ToListAsync();

            ViewData["Title"] = "Consulta de Eventos";

            return View(eventos);
        }

        public async Task<IActionResult> EventosPendentes()
        {
            EventosPendentesViewModel eventosPendentes = new EventosPendentesViewModel()
            {
                EventosPendentes = await BuscaEventosPendentes(),
                ResumoFKS = await BuscaResumoFKS()
            };

            return View(eventosPendentes);
        }

        private async Task<List<EventoIndexViewModel>> BuscaEventosPendentes()
        {
            // Modificado para usar JOINs explícitos e um ViewModel específico para a listagem
            var eventos = await (from Evento in _dbContext.Evento
                                 join Cliente in _dbContext.Cliente
                                    on Evento.IdCliente equals Cliente.IdCliente //into cGroup
                                 join Receptora in _dbContext.Receptora
                                    on Cliente.IdReceptora equals Receptora.IdReceptora
                                 join EventoMonitoramento in _dbContext.EventoMonitoramento
                                    on Evento.IdEvento equals EventoMonitoramento.IdEvento //into emGroup
                                 join ReceptoraAcao in _dbContext.ReceptoraAcao
                                    on Receptora.IdReceptora equals ReceptoraAcao.IdReceptora
                                 join EventoEstadoAcao in _dbContext.EventoEstadoAcao
                                    on Evento.Evento1 equals EventoEstadoAcao.CodigoEvento
                                 where EventoMonitoramento.Concluido == false
                                    && ReceptoraAcao.IdEventoEstadoAcao == EventoEstadoAcao.Id
                                    && ReceptoraAcao.GeraAtendimento == true
                                 orderby Evento.DataHora descending
                                 select new EventoIndexViewModel
                                 {
                                     IdEvento = Evento.IdEvento,
                                     ReceptoraNome = Receptora.Nome,
                                     NumeroEvento = Evento.IdEvento,
                                     Conta = Cliente.Codigo + (String.IsNullOrEmpty(Cliente.Particao) ? "" : $" - {Cliente.Particao}"),
                                     NomeCliente = Cliente.Nome, // Obtém o nome do cliente através do join
                                     IdCliente = Cliente.IdCliente, // Obtém o nome do cliente através do join
                                     DataEvento = Evento.DataHora,
                                     TipoEvento = $"{Evento.Evento1} - {EventoEstadoAcao.Decricao}", // Mapeado para Tipo Evento na tela
                                     DisparaSom = ReceptoraAcao != null ? ReceptoraAcao.DisparaSom : false
                                 })
                                 .Take(1000) // Limita para fins de demonstração e performance
                                 .ToListAsync();

            ViewData["Title"] = "Consulta de Eventos Pendentes";

            var eventosFiltrados = new List<EventoIndexViewModel>();

            var eventosAgrupados = eventos.GroupBy(g => new { g.IdCliente, g.TipoEvento })
                .Select(s =>
                    new
                    {
                        IdEvento = s.ToList().Max(o => o.IdEvento),
                        Count = s.ToList().Count()
                    }
                )
                .ToList();

            foreach (var g in eventosAgrupados)
            {
                //var event = eventos.First(e => e.IdEvento.Equals(g.IdEvento));
                //eventosFiltrados.Add();
                EventoIndexViewModel evento = eventos.First(e => e.IdEvento.Equals(g.IdEvento));
                evento.QtdEvento = g.Count;
                eventosFiltrados.Add(evento);
            }

            return eventosFiltrados;
        }

        [HttpPost]
        public async Task<IActionResult> CheckEventosPendentesAsync(List<int> eventosIds, string resumoFKS)
        {

            List<EventoIndexViewModel> eventosFiltrados = await BuscaEventosPendentes();

            var qtdNovosEventoPendente = eventosFiltrados.Count(e => !eventosIds.Contains(e.IdEvento));
            var qtdNovosEventoPendenteDisparaSom = eventosFiltrados.Count(e => !eventosIds.Contains(e.IdEvento) && e.DisparaSom);
            var qtdEventoAtendidos = eventosIds.Count(e => !eventosFiltrados.Any(f => f.IdEvento == e));

            var lstResumoFKS = await BuscaResumoFKS();
            var atualResumoFKS = string.Join("-", lstResumoFKS.Select(e => e.Qtd.ToString()));

            //Verifica quantos segundos se passaram da ultima mensagem da recetora 2
            var receptora2 = await _dbContext.Receptora.FirstOrDefaultAsync(r => r.IdReceptora == 2);
            var segundosUltimaMensagemFKS = 120; // Valor padrão caso seja nulo
            if (receptora2 != null)
            {
                segundosUltimaMensagemFKS = (int)(DateTime.UtcNow.AddHours(-3) - receptora2.UltimaMensagem).Value.TotalSeconds;
            }

            return Ok(new { 
                reloadPage = qtdNovosEventoPendente > 0 || qtdEventoAtendidos > 0 || atualResumoFKS != resumoFKS,
                disparaSom = qtdNovosEventoPendenteDisparaSom > 0,
                segundosUltimaMensagemFKS = segundosUltimaMensagemFKS
            });
        }

        // Action para exibir o formulário de criação/edição de evento
        [HttpGet]
        public async Task<IActionResult> Create(int? id, bool eventoPendente = false)
        {
            var model = new EventoViewModel();

            model.EventoPendente = eventoPendente;

            await carregaDadosDropDown(model);

            if (id.HasValue)
            {
                // Carrega o Evento principal
                var evento = await _dbContext.Evento.FindAsync(id);

                if (evento != null)
                {
                    // Mapeia dados do Evento para o ViewModel
                    model.IdEvento = evento.IdEvento;
                    model.EvtRest = evento.EvtRest;
                    model.Conta = evento.Conta;
                    model.Evento1 = evento.Evento1;
                    model.Grupo = evento.Grupo;
                    model.Zona = evento.Zona;
                    model.IdFormato = evento.IdFormato;
                    model.SinalCelular = evento.SinalCelular;
                    model.TipoRede = evento.TipoRede;
                    model.DataHoraEvento = evento.DataHora;
                    model.IdReceptora = evento.IdReceptora;
                    model.QtdEventos = evento.QtdEventos;

                    // Tenta buscar a descrição do tipo de evento
                    var codEvento = "E" + evento.Evento1;
                    var tipoEvento = await _dbContext.TipoEvento.FirstOrDefaultAsync(te => te.Evento == codEvento);
                    if (tipoEvento != null)
                    {
                        model.TipoEventoDescricao = tipoEvento.Descricao;
                    }

                    // Carrega EventoMonitoramento
                    var eventoMonitoramento = await _dbContext.EventoMonitoramento
                        .Include(em => em.Usuario) // Inclui o usuário para pegar o nome
                        .FirstOrDefaultAsync(em => em.IdEvento == id);

                    if (eventoMonitoramento != null)
                    {
                        model.IdEventoMonitoramento = eventoMonitoramento.IdEventoMonitoramento;
                        model.NumeroMonitoramento = eventoMonitoramento.IdEventoMonitoramento; // Mapeia para o mesmo campo visualmente
                        model.EventoMonitoradoIdEvento = eventoMonitoramento.IdEvento;
                        model.IdUsuarioAtendimento = eventoMonitoramento.IdUsuario;
                        model.NomeUsuarioAtendimento = eventoMonitoramento.Usuario?.Nome; // Pega o nome do usuário
                        model.Atendimento = eventoMonitoramento.Atendimento ?? false; // Garante valor não nulo
                        model.ConcluidoAtendimento = eventoMonitoramento.Concluido ?? false; // Garante valor não nulo
                        model.AtivoAtendimento = eventoMonitoramento.Ativo ?? false; // Garante valor não nulo
                        model.DataHoraInicioAtendimento = eventoMonitoramento.DataHoraInicio;
                        model.DataHoraTerminoAtendimento = eventoMonitoramento.DataHoraTermino;
                        model.DescricaoMonitoramento = eventoMonitoramento.DescricaoMonitoramento;
                    }

                    // Carrega SMEAC
                    var smeac = await _dbContext.SMEAC.FirstOrDefaultAsync(s => s.IdEventoMonitoramento == (eventoMonitoramento != null ? eventoMonitoramento.IdEventoMonitoramento : (int?)null));

                    if (smeac != null)
                    {
                        model.IdSMEAC = smeac.IdSMEAC;
                        model.NumeroSolicitacaoSMEAC = smeac.IdSMEAC; // Mapeia para o mesmo campo visualmente
                        model.DataSolInicioSMEAC = smeac.DataSolInicio;
                        model.DataSolTerminoSMEAC = smeac.DataSolTermino;
                        model.ConcluidoSolSMEAC = smeac.ConcluidoSol ?? false; // Garante valor não nulo

                        // Carrega DetalhesSMEAC
                        var detalhesSMEAC = await _dbContext.DetalhesSMEAC
                            .Where(ds => ds.IdSMEAC == smeac.IdSMEAC)
                            .Include(ds => ds.Usuario) // Inclui o usuário para pegar o nome
                            .Include(ds => ds.Veiculo) // Inclui o veículo para pegar marca/modelo/placa
                            .ToListAsync();

                        foreach (var detalhe in detalhesSMEAC)
                        {
                            model.DetalhesSMEAC.Add(new DetalhesSMEACViewModel
                            {
                                IdDetalhesSMEAC = detalhe.IdDetalhesSMEAC,
                                IdSMEAC = detalhe.IdSMEAC,
                                IdUsuarioCampo = detalhe.IdUsuario,
                                NomeUsuarioCampo = detalhe.Usuario?.Nome,
                                IdVeiculoAtendimento = detalhe.IdVeiculo,
                                DescricaoVeiculoAtendimento = $"{detalhe.Veiculo?.Marca} {detalhe.Veiculo?.Modelo} ({detalhe.Veiculo?.Placa})",
                                DescricaoDetalhe = detalhe.DescricaoDetalhe,
                                DataDetalheChegada = detalhe.DataDetalheChegada,
                                DataDetalheSaida = detalhe.DataDetalheSaida,
                                KM = "" // Campo KM não tem mapeamento direto na estrutura fornecida
                            });
                        }
                    }
                }
            }
            else
            {
                // Para uma nova criação, defina valores padrão se necessário
                model.DataHoraEvento = DateTime.Now;
                model.DataHoraInicioAtendimento = DateTime.Now;
                // Outros padrões
            }

            return View(model);
        }

        private async Task carregaDadosDropDown(EventoViewModel model)
        {
            // Carrega os dados para os dropdowns do ViewModel
            model.Usuarios = await _dbContext.Usuario
                .Where(u => u.Status.Value)
                .OrderBy(u => u.Nome)
                .Select(u => new SelectListItem
                {
                    Value = u.IdUsuario.ToString(),
                    Text = u.Nome
                }).ToListAsync();

            model.Veiculos = await _dbContext.Veiculo
                .Select(v => new SelectListItem
                {
                    Value = v.IdVeiculo.ToString(),
                    Text = $"{v.Marca} {v.Modelo} ({v.Placa})"
                }).ToListAsync();

            model.TiposEvento = await _dbContext.TipoEvento
                .Select(te => new SelectListItem
                {
                    Value = te.IdTipoEvento.ToString(), // Pode ser o Id ou outro campo relevante
                    Text = te.Descricao // Usa a descrição do TipoEvento
                }).ToListAsync();

            model.DescricaoAtend = await _dbContext.DescricaoAtend
                .Select(d => new SelectListItem
                {
                    Value = d.IdDescricaoAtend.ToString(),
                    Text = d.DescricaoAtend1
                }).ToListAsync();

            // Passa as listas para a ViewBag para que partial views possam acessá-las
            ViewBag.Usuarios = model.Usuarios;
            ViewBag.Veiculos = model.Veiculos;
            ViewBag.TiposEvento = model.TiposEvento;
        }

        // Action para processar o POST do formulário de criação/edição
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventoViewModel model)
        {
            //return new JsonResult(model);

            // Recarrega os dropdowns em caso de erro de validação ANTES de remover os estados
            await carregaDadosDropDown(model);

            // Remove a validação do campo TipoEventoDescricao, pois ele é apenas para exibição
            ModelState.Remove("TipoEventoDescricao");
            ModelState.Remove("NomeUsuarioAtendimento");
            ModelState.Remove("NomeUsuarioCampo");
            ModelState.Remove("DescricaoVeiculoAtendimento");
            ModelState.Remove("KM"); // KM não é um campo do modelo de dados
            // Remova o estado de campos que podem ser nulos no banco de dados, mas são bool? no ViewModel
            ModelState.Remove("Atendimento");
            ModelState.Remove("ConcluidoAtendimento");
            ModelState.Remove("AtivoAtendimento");
            ModelState.Remove("ConcluidoSolSMEAC");


            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // ===============================================
            // Salvar Evento
            // ===============================================
            Evento evento = await _dbContext.Evento.FindAsync(model.IdEvento);

            if (evento == null)
            {
                TempData["ErrorMessage"] = "Evento não encontrado para edição.";
                return RedirectToAction("Index");
            }


            // ===============================================
            // Salvar EventoMonitoramento
            // ===============================================
            EventoMonitoramento eventoMonitoramento;
            if (model.IdEventoMonitoramento.HasValue && model.IdEventoMonitoramento.Value > 0)
            {
                eventoMonitoramento = await _dbContext.EventoMonitoramento.FindAsync(model.IdEventoMonitoramento.Value);
                if (eventoMonitoramento == null)
                {
                    // Se não encontrou o monitoramento existente, cria um novo
                    eventoMonitoramento = new EventoMonitoramento();
                    _dbContext.EventoMonitoramento.Add(eventoMonitoramento);
                }
            }
            else
            {
                eventoMonitoramento = new EventoMonitoramento();
                _dbContext.EventoMonitoramento.Add(eventoMonitoramento);
            }

            //Verifica se a data de término não foi informada e se o atendimento está sendo concluído, então registra a data de término
            if (!model.DataHoraTerminoAtendimento.HasValue &&
                (!eventoMonitoramento.Concluido.HasValue || (eventoMonitoramento.Concluido.HasValue && !eventoMonitoramento.Concluido.Value)) &&
                model.ConcluidoAtendimento
                )
            {
                eventoMonitoramento.DataHoraTermino = DateTime.UtcNow.AddHours(-3);
            }
            else
            {
                eventoMonitoramento.DataHoraTermino = model.DataHoraTerminoAtendimento;
            }

            eventoMonitoramento.IdEvento = evento.IdEvento; // Vincula ao evento recém-salvo/atualizado
            eventoMonitoramento.IdUsuario = model.IdUsuarioAtendimento;
            eventoMonitoramento.Atendimento = model.Atendimento;
            eventoMonitoramento.Concluido = model.ConcluidoAtendimento;
            eventoMonitoramento.Ativo = model.AtivoAtendimento;
            eventoMonitoramento.DataHoraInicio = model.DataHoraInicioAtendimento;
            eventoMonitoramento.DescricaoMonitoramento = model.DescricaoMonitoramento;
            //eventoMonitoramento.IdReceptora = model.IdReceptora; // Usando o mesmo ID da receptora do evento principal

            await _dbContext.SaveChangesAsync();

            // ===============================================
            // Se está Concluindo o evento, fecha todos eventos abertos com ID inferior
            // ===============================================
            if (eventoMonitoramento.Concluido.Value)
            {
                //Fecha os eventos anteriores
                String SQL = @$"
                    UPDATE evento_monitoramento 
	                    set concluido = 1,
	                    descricao_monitoramento = 'EVENTO DUPLICADO - CONCLUÍDO AUTOMATICAMENTE'
                    FROM [dbo].[evento] E
                    Inner Join evento_monitoramento EM
	                    ON EM.id_evento = e.id_evento
                    Where E.idCliente = '{evento.IdCliente}'
                      and E.evento = '{evento.Evento1}'
                      and EM.concluido = 0
                      and EM.id_evento < {evento.IdEvento}
                ";

                var result = await _dbContext.Database.ExecuteSqlRawAsync(SQL);


            }

            // ===============================================
            // Salvar SMEAC
            // ===============================================
            SMEAC smeac;
            if (model.IdSMEAC.HasValue && model.IdSMEAC.Value > 0)
            {
                smeac = await _dbContext.SMEAC.FindAsync(model.IdSMEAC.Value);
                if (smeac == null)
                {
                    // Se não encontrou a SMEAC existente, cria uma nova
                    smeac = new SMEAC();
                    smeac.DataSolInicio = DateTime.UtcNow.AddHours(-3);
                    _dbContext.SMEAC.Add(smeac);
                }
            }
            else
            {
                smeac = new SMEAC();
                smeac.DataSolInicio = DateTime.UtcNow.AddHours(-3);
                _dbContext.SMEAC.Add(smeac);
            }

            smeac.IdEventoMonitoramento = eventoMonitoramento.IdEventoMonitoramento; // Vincula ao EventoMonitoramento

            //Verifica se a solicitação está sendo concluída e registra a data de termino
            if ((!smeac.ConcluidoSol.HasValue || (smeac.ConcluidoSol.HasValue && !smeac.ConcluidoSol.Value)) && model.ConcluidoSolSMEAC)
            {
                smeac.DataSolTermino = DateTime.UtcNow.AddHours(-3);
            }

            smeac.ConcluidoSol = model.ConcluidoSolSMEAC;

            await _dbContext.SaveChangesAsync();

            // ===============================================
            // Salvar DetalhesSMEAC (Itera sobre a lista)
            // ===============================================
            // Para lidar com remoções e adições dinâmicas, o ideal seria comparar
            // o que veio do formulário com o que está no banco e adicionar/remover/atualizar.
            // Por simplicidade, este exemplo atualiza ou adiciona.
            // Para remoção, seria necessário um mecanismo no cliente (ex: hidden field para marcar para remoção).

            // Pega os IDs dos detalhes existentes no banco de dados para este SMEAC
            var existingDetalhesIds = await _dbContext.DetalhesSMEAC
                                                    .Where(ds => ds.IdSMEAC == smeac.IdSMEAC)
                                                    .Select(ds => ds.IdDetalhesSMEAC)
                                                    .ToListAsync();

            // Pega os IDs dos detalhes que foram enviados pelo formulário
            var submittedDetalhesIds = model.DetalhesSMEAC?.Where(ds => ds.IdDetalhesSMEAC.HasValue).Select(ds => ds.IdDetalhesSMEAC.Value).ToList() ?? new List<int>();

            // Remove detalhes que foram excluídos na interface do usuário
            var detalhesToRemove = existingDetalhesIds.Except(submittedDetalhesIds).ToList();
            foreach (var idToRemove in detalhesToRemove)
            {
                var detalhe = await _dbContext.DetalhesSMEAC.FindAsync(idToRemove);
                if (detalhe != null)
                {
                    _dbContext.DetalhesSMEAC.Remove(detalhe);
                }
            }

            if (model.DetalhesSMEAC != null && model.DetalhesSMEAC.Any())
            {
                foreach (var detalheModel in model.DetalhesSMEAC)
                {
                    DetalhesSMEAC detalheDb;
                    if (detalheModel.IdDetalhesSMEAC.HasValue && detalheModel.IdDetalhesSMEAC.Value > 0)
                    {
                        detalheDb = await _dbContext.DetalhesSMEAC.FindAsync(detalheModel.IdDetalhesSMEAC.Value);
                        if (detalheDb == null) continue; // Pula se não encontrar o detalhe existente
                    }
                    else
                    {
                        detalheDb = new DetalhesSMEAC();
                        _dbContext.DetalhesSMEAC.Add(detalheDb);
                    }

                    detalheDb.IdSMEAC = smeac.IdSMEAC; // Vincula ao SMEAC
                    detalheDb.IdUsuario = detalheModel.IdUsuarioCampo;
                    detalheDb.IdVeiculo = detalheModel.IdVeiculoAtendimento;
                    detalheDb.DescricaoDetalhe = detalheModel.DescricaoDetalhe;
                    detalheDb.DataDetalheChegada = detalheModel.DataDetalheChegada;
                    detalheDb.DataDetalheSaida = detalheModel.DataDetalheSaida;
                    // O campo KM no ViewModel não tem um mapeamento direto no modelo de dados 'DetalhesSMEAC'
                    // Se for para ser salvo, precisaria de um campo na tabela DetalhesSMEAC ou uma lógica separada.
                }
                await _dbContext.SaveChangesAsync();
            }

            TempData["SuccessMessage"] = "Evento salvo com sucesso!";

            if (model.EventoPendente)
            {
                return RedirectToAction("EventosPendentes");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        // Action para adicionar um novo item de DetalhesSMEAC via AJAX
        [HttpPost]
        public async Task<IActionResult> AddDetalheSMEAC(int index)
        {
            // Popula as ViewBags para que o PartialView possa renderizar os dropdowns
            ViewBag.Usuarios = await _dbContext.Usuario
                .Where(u => u.Status.Value)
                .OrderBy(u => u.Nome)
                .Select(u => new SelectListItem
                {
                    Value = u.IdUsuario.ToString(),
                    Text = u.Nome
                }).ToListAsync();

            ViewBag.Veiculos = await _dbContext.Veiculo
                .Select(v => new SelectListItem
                {
                    Value = v.IdVeiculo.ToString(),
                    Text = $"{v.Marca} {v.Modelo} ({v.Placa})"
                }).ToListAsync();

            ViewData["Index"] = index;

            // Retorna uma partial view com um novo item de DetalhesSMEACViewModel
            return PartialView("_DetalhesSMEACRow", new DetalhesSMEACViewModel());
        }

        public async Task<List<ResumoFKSViewModel>> BuscaResumoFKS()
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(@"
                Declare @id_evento_estado int = 1

                Select 
	                EE.id id_evento_estado,
					EE.descricao grupo_evento,
	                EEA.decricao,
	                EEA.cor,
	                0 Qtd
                Into #TMP
                from evento_estado EE
                Inner Join evento_estado_acao EEA
	                On EEA.id_evento_estado = EE.id
                Group By 
	                EE.id,
					EE.descricao,
	                EEA.decricao,
	                EEA.cor
	

                While @id_evento_estado <= 6
                Begin
	                Declare @EE_descricao nvarchar(50)
	                Declare @EE_cor_ausente nvarchar(50)

	                Select 
		                @EE_descricao = EE.descricao,
		                @EE_cor_ausente = EE.cor_ausente
	                From evento_estado EE
	                Where EE.id = @id_evento_estado

	                Insert Into #TMP(id_evento_estado, grupo_evento, decricao, cor, Qtd)
	                Select 
		                E.id_evento_estado,
		                @EE_descricao,
						EEA.decricao,
		                EEA.cor,
		                count(*) Qtd
	                From evento E
	                Inner Join evento_estado_acao EEA
		                On EEA.cod_evento = E.evento
	                Where E.id_receptora = 2 -- FKS
		                and E.id_evento_estado = @id_evento_estado
		                and Not Exists( -- Onde não existe outro evento do mesmo cliente e grupo de eventos mais recente
		                Select Top 1 1
		                From evento E2
		                Where E2.IdCliente = E.IdCliente
			                and E2.id_evento_estado = @id_evento_estado
			                and E2.data_hora > E.data_hora
		                )
	                Group By E.id_evento_estado,
		                E.evento,
		                EEA.decricao,
		                EEA.cor

	                Set @id_evento_estado = @id_evento_estado + 1
                End

                Select 
	                T.id_evento_estado,
					T.grupo_evento,
	                T.decricao,
	                T.cor,
	                SUM(T.Qtd) Qtd
                From #TMP T
                Group By T.id_evento_estado,
	                T.grupo_evento,
					T.decricao,
	                T.cor
                Order By T.id_evento_estado,
	                T.cor Desc

                Drop Table #TMP

            ");

            // Use the explicit type argument for SqlQueryRaw
            var query = _dbContext.Database.SqlQueryRaw<ResumoFKSViewModel>(sql.ToString());

            // If you want to execute and get the results as a list:
            return await query.ToListAsync();
        }

        public async Task<IActionResult> Simulador()
        {
            return View();
        }
    }

    // 1. Define a result class for your query (place this in an appropriate namespace/file if reused elsewhere):
    public class ResumoFKSViewModel
    {
        public int id_evento_estado { get; set; }
        public string grupo_evento { get; set; }
        public string decricao { get; set; }
        public string cor { get; set; }
        public int Qtd { get; set; }
    }
}
