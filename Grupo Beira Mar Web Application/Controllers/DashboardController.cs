using Grupo_Beira_Mar_Web_Application.Data;
using Grupo_Beira_Mar_Web_Application.DataModels;
using Grupo_Beira_Mar_Web_Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupo_Beira_Mar_Web_Application.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public DashboardController(
            ILogger<DashboardController> logger,
            ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var model = new DashboardViewModel();

            // =========================================================
            // 1. Visão Geral (Cards de Indicadores Chave)
            // =========================================================
            var now = DateTime.Now;
            var startOfDay = now.Date;
            var startOfMonth = new DateTime(now.Year, now.Month, 1);
            var startOfYear = new DateTime(now.Year, 1, 1);

            model.TotalEventosRegistradosHoje = await _dbContext.Evento
                .CountAsync(e => e.DataHora.HasValue && e.DataHora.Value.Date == startOfDay);
            model.TotalEventosRegistradosMes = await _dbContext.Evento
                .CountAsync(e => e.DataHora.HasValue && e.DataHora.Value.Month == now.Month && e.DataHora.Value.Year == now.Year);
            model.TotalEventosRegistradosAno = await _dbContext.Evento
                .CountAsync(e => e.DataHora.HasValue && e.DataHora.Value.Year == now.Year);

            // Eventos Pendentes de Atendimento: Aqueles que não estão concluídos
            model.EventosPendentesAtendimento = await _dbContext.EventoMonitoramento
                .CountAsync(em => em.Concluido == false || em.Concluido == null);

            model.EventosConcluidosHoje = await _dbContext.EventoMonitoramento
                .CountAsync(em => em.Concluido == true && em.DataHoraTermino.HasValue && em.DataHoraTermino.Value.Date == startOfDay);
            model.EventosConcluidosMes = await _dbContext.EventoMonitoramento
                .CountAsync(em => em.Concluido == true && em.DataHoraTermino.HasValue && em.DataHoraTermino.Value.Month == now.Month && em.DataHoraTermino.Value.Year == now.Year);
            model.EventosConcluidosAno = await _dbContext.EventoMonitoramento
                .CountAsync(em => em.Concluido == true && em.DataHoraTermino.HasValue && em.DataHoraTermino.Value.Year == now.Year);

            // Tempo Médio de Atendimento
            var atendimentosConcluidos = await _dbContext.EventoMonitoramento
                .Where(em => em.Concluido == true && em.DataHoraInicio.HasValue && em.DataHoraTermino.HasValue)
                .Select(em => (em.DataHoraTermino.Value - em.DataHoraInicio.Value).TotalMinutes)
                .ToListAsync();

            if (atendimentosConcluidos.Any())
            {
                model.TempoMedioAtendimento = TimeSpan.FromMinutes(atendimentosConcluidos.Average());
            }

            model.TotalSolicitacoesAtendimentoSMEAC = await _dbContext.SMEAC.CountAsync();
            model.SolicitacoesAtendimentoPendentes = await _dbContext.SMEAC
                .CountAsync(s => s.ConcluidoSol == false || s.ConcluidoSol == null);


            // =========================================================
            // 2. Estatísticas de Eventos (Dados para Gráficos)
            // =========================================================

            // Eventos por Mês (últimos 12 meses)
            var eventosPorMes = await _dbContext.Evento
                .Where(e => e.DataHora.HasValue)
                .GroupBy(e => new { e.DataHora.Value.Year, e.DataHora.Value.Month })
                .Select(g => new { Year = g.Key.Year, Month = g.Key.Month, Count = g.Count() })
                .OrderBy(x => x.Year)
                .ThenBy(x => x.Month)
                .ToListAsync();

            var startOfCurrentMonth = new DateTime(now.Year, now.Month, 1);
            var last12Months = Enumerable.Range(0, 12)
                                .Select(i => startOfCurrentMonth.AddMonths(-i))
                                .OrderBy(d => d)
                                .ToList();

            foreach (var month in last12Months)
            {
                model.EventosPorPeriodoLabels.Add(month.ToString("MMM/yy"));
                var count = eventosPorMes.FirstOrDefault(x => x.Year == month.Year && x.Month == month.Month)?.Count ?? 0;
                model.EventosPorPeriodoData.Add(count);
            }

            // Eventos por Tipo (Top N)
            var eventosPorTipo = await _dbContext.Evento
                .Where(e => !string.IsNullOrEmpty(e.Evento1))
                .GroupBy(e => e.Evento1)
                .Select(g => new { Tipo = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .Take(5)
                .ToListAsync();

            model.EventosPorTipoLabels = eventosPorTipo.Select(x => x.Tipo).ToList();
            model.EventosPorTipoData = eventosPorTipo.Select(x => x.Count).ToList();

            // Status dos Eventos (Atendimento)
            var statusAtendimento = await _dbContext.EventoMonitoramento
                .GroupBy(em => new
                {
                    Atendimento = em.Atendimento ?? false,
                    Concluido = em.Concluido ?? false
                })
                .Select(g => new { Key = g.Key, Count = g.Count() })
                .ToListAsync();

            model.EventosPorStatusLabels.Add("Atendidos (Não Concluídos)");
            model.EventosPorStatusData.Add(statusAtendimento.FirstOrDefault(s => s.Key.Atendimento && !s.Key.Concluido)?.Count ?? 0);

            model.EventosPorStatusLabels.Add("Concluídos");
            model.EventosPorStatusData.Add(statusAtendimento.FirstOrDefault(s => s.Key.Concluido)?.Count ?? 0);

            model.EventosPorStatusLabels.Add("Pendentes (Não Atendidos)");
            model.EventosPorStatusData.Add(statusAtendimento.FirstOrDefault(s => !s.Key.Atendimento && !s.Key.Concluido)?.Count ?? 0);


            // =========================================================
            // 3. Desempenho do Atendimento
            // =========================================================

            // Atendimentos por Usuário
            var rawAtendimentosPorUsuario = await _dbContext.EventoMonitoramento
                .Where(em => em.IdUsuario.HasValue)
                .Include(em => em.Usuario)
                .ToListAsync(); // Trazer para memória para agrupar por nome

            var atendimentosPorUsuario = rawAtendimentosPorUsuario
                .GroupBy(em => em.Usuario?.Nome ?? "Usuário Desconhecido") // Agrupar em memória
                .Select(g => new { UserName = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .Take(5)
                .ToList();

            model.AtendimentosPorUsuarioLabels = atendimentosPorUsuario.Select(x => x.UserName).ToList();
            model.AtendimentosPorUsuarioData = atendimentosPorUsuario.Select(x => x.Count).ToList();

            // Tempo de Resposta e Conclusão (exemplo mensal) - CORREÇÃO APLICADA AQUI
            var rawTempoMedioMensal = (from em in _dbContext.EventoMonitoramento
                                             join e in _dbContext.Evento on em.IdEvento equals e.IdEvento
                                             where em.DataHoraInicio.HasValue && em.DataHoraTermino.HasValue && em.Concluido == true && e.DataHora.HasValue
                                             select new
                                             {
                                                 Year = em.DataHoraTermino.Value.Year,
                                                 Month = em.DataHoraTermino.Value.Month,
                                                 ResponseTimeSpan = em.DataHoraInicio.Value - e.DataHora.Value,
                                                 CompletionTimeSpan = em.DataHoraTermino.Value - e.DataHora.Value
                                             })
                                          .AsEnumerable() // Forces client-side evaluation from this point
                                          .ToList(); // Materializa para lista antes da próxima operação

            var tempoMedioMensal = rawTempoMedioMensal
                .GroupBy(x => new { x.Year, x.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    AvgResponseTime = g.Average(x => x.ResponseTimeSpan.TotalMinutes), // TotalMinutes agora é acessado em memória
                    AvgCompletionTime = g.Average(x => x.CompletionTimeSpan.TotalMinutes) // TotalMinutes agora é acessado em memória
                })
                .OrderBy(x => x.Year)
                .ThenBy(x => x.Month)
                .ToList();

            foreach (var month in last12Months)
            {
                model.TempoRespostaConclusaoLabels.Add(month.ToString("MMM/yy"));
                var data = tempoMedioMensal.FirstOrDefault(x => x.Year == month.Year && x.Month == month.Month);
                model.TempoRespostaData.Add(data?.AvgResponseTime ?? 0);
                model.TempoConclusaoData.Add(data?.AvgCompletionTime ?? 0);
            }


            // =========================================================
            // 4. Atividade de Campo
            // =========================================================

            // Ocorrências por Veículo Atendimento - CORREÇÃO APLICADA AQUI
            var rawOcorrenciasPorVeiculo = await _dbContext.DetalhesSMEAC
                .Where(ds => ds.IdVeiculo.HasValue)
                .Include(ds => ds.Veiculo)
                .ToListAsync(); // Trazer para memória para formatação e agrupamento

            var ocorrenciasPorVeiculo = rawOcorrenciasPorVeiculo
                .GroupBy(ds => ds.Veiculo != null ? $"{ds.Veiculo.Marca} {ds.Veiculo.Modelo} ({ds.Veiculo.Placa})" : "Veículo Desconhecido")
                .Select(g => new { VeiculoInfo = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .Take(5)
                .ToList();

            model.OcorrenciasPorVeiculoLabels = ocorrenciasPorVeiculo.Select(x => x.VeiculoInfo).ToList();
            model.OcorrenciasPorVeiculoData = ocorrenciasPorVeiculo.Select(x => x.Count).ToList();

            // Ocorrências por Vigilante Campo - CORREÇÃO APLICADA AQUI
            var rawOcorrenciasPorVigilante = await _dbContext.DetalhesSMEAC
                .Where(ds => ds.IdUsuario.HasValue)
                .Include(ds => ds.Usuario)
                .ToListAsync(); // Trazer para memória para agrupamento

            var ocorrenciasPorVigilante = rawOcorrenciasPorVigilante
                .GroupBy(ds => ds.Usuario?.Nome ?? "Usuário Desconhecido")
                .Select(g => new { UserName = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .Take(5)
                .ToList();

            model.OcorrenciasPorVigilanteCampoLabels = ocorrenciasPorVigilante.Select(x => x.UserName).ToList();
            model.OcorrenciasPorVigilanteCampoData = ocorrenciasPorVigilante.Select(x => x.Count).ToList();

            // Últimas Solicitações de Atendimento (SMEAC) - CORREÇÃO APLICADA AQUI
            // Para evitar problemas de tradução com subconsultas aninhadas,
            // vamos carregar as SMEACs e depois os detalhes em memória.
            var rawSMEACs = await _dbContext.SMEAC
                .OrderByDescending(s => s.DataSolInicio)
                .Take(10)
                .ToListAsync();

            var ultimasSolicitacoes = new List<SMEACTableItem>();

            foreach (var s in rawSMEACs)
            {
                var firstDetail = await _dbContext.DetalhesSMEAC
                    .Where(ds => ds.IdSMEAC == s.IdSMEAC)
                    .Include(ds => ds.Usuario)
                    .Include(ds => ds.Veiculo)
                    .OrderBy(ds => ds.IdDetalhesSMEAC) // Order para pegar o "primeiro" consistente
                    .FirstOrDefaultAsync(); // Trazer o primeiro detalhe para memória

                ultimasSolicitacoes.Add(new SMEACTableItem
                {
                    NumeroSolicitacao = s.IdSMEAC,
                    NumeroMonitoramento = s.IdEventoMonitoramento,
                    DataInicioSolicitacao = s.DataSolInicio,
                    DataTerminoSolicitacao = s.DataSolTermino,
                    ConcluidoSolicitacao = s.ConcluidoSol ?? false,
                    DescricaoDetalhe = firstDetail?.DescricaoDetalhe,
                    VigilanteCampo = firstDetail?.Usuario?.Nome,
                    VeiculoAtendimento = firstDetail?.Veiculo != null ? $"{firstDetail.Veiculo.Marca} ({firstDetail.Veiculo.Placa})" : null
                });
            }
            model.UltimasSolicitacoesSMEAC = ultimasSolicitacoes;


            // =========================================================
            // 5. Análise Geográfica (usando Cliente.Estado/Cidade)
            // =========================================================
            // Para isso, precisamos relacionar Eventos com Clientes e suas localizações.
            // Assumimos que Evento.Conta pode ser relacionado a ClienteMonitoramento.Conta
            // e, em seguida, ClienteMonitoramento.IdCliente para Cliente.IdCliente.
            var eventosPorLocalizacao = await (from e in _dbContext.Evento
                                               join cm in _dbContext.ClienteMonitoramento on e.Conta equals cm.Conta into cmGroup
                                               from cm in cmGroup.DefaultIfEmpty()
                                               join c in _dbContext.Cliente on cm.IdCliente equals c.IdCliente into cGroup
                                               from c in cGroup.DefaultIfEmpty()
                                               where c != null && !string.IsNullOrEmpty(c.Estado)
                                               group e by c.Estado into g
                                               select new { Estado = g.Key, Count = g.Count() })
                                             .OrderByDescending(x => x.Count)
                                             .Take(10) // Top 10 estados com mais eventos
                                             .ToListAsync();

            model.EventosPorLocalizacaoLabels = eventosPorLocalizacao.Select(x => x.Estado).ToList();
            model.EventosPorLocalizacaoData = eventosPorLocalizacao.Select(x => x.Count).ToList();


            return View(model);
        }
    }
}
