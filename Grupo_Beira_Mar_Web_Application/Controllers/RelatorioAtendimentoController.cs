using ClosedXML.Excel;
using Grupo_Beira_Mar_Web_Application.Data;
using Grupo_Beira_Mar_Web_Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Grupo_Beira_Mar_Web_Application.Controllers
{
    public class RelatorioAtendimentoController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public RelatorioAtendimentoController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> Index(RelatorioAtendimentoViewModel viewModel)
        {
            // Populate filter selects
            ViewBag.Receptoras = await _dbContext.Receptora
                .OrderBy(r => r.Nome)
                .Select(r => new SelectListItem { Value = r.IdReceptora.ToString(), Text = r.Nome })
                .ToListAsync();

            ViewBag.TipoEventos = await _dbContext.EventoEstadoAcao
                .OrderBy(e => e.IdEventoEstado).ThenByDescending(e => e.Cor)
                .Select(e => new SelectListItem { Value = e.CodigoEvento, Text = e.Decricao })
                .ToListAsync();

            // Execute query
            var itens = await ConsultaAtendimentosAsync(viewModel);

            viewModel ??= new RelatorioAtendimentoViewModel();
            viewModel.Itens = itens;
            viewModel.Filtros ??= new RelatorioAtendimentoFiltrosViewModel();

            return View(viewModel);
        }

        private async Task<List<RelatorioAtendimentoItemViewModel>> ConsultaAtendimentosAsync(RelatorioAtendimentoViewModel viewModel)
        {
            // Defaults for dates: today if not provided
            if (viewModel?.Filtros == null)
            {
                viewModel ??= new RelatorioAtendimentoViewModel();
                viewModel.Filtros = new RelatorioAtendimentoFiltrosViewModel();
            }
            if (!viewModel.Filtros.DataInicial.HasValue)
            {
                viewModel.Filtros.DataInicial = DateTime.UtcNow.AddHours(-3).Date;
            }
            if (!viewModel.Filtros.DataFinal.HasValue)
            {
                viewModel.Filtros.DataFinal = DateTime.UtcNow.AddHours(-3).Date.AddDays(1);
            }

            var query = from e in _dbContext.Evento
                        join c in _dbContext.Cliente on e.IdCliente equals c.IdCliente
                        join r in _dbContext.Receptora on c.IdReceptora equals r.IdReceptora
                        join em in _dbContext.EventoMonitoramento on e.IdEvento equals em.IdEvento into emg
                        from em in emg.DefaultIfEmpty()
                        join u in _dbContext.Usuario on em.IdUsuario equals u.IdUsuario into ug
                        from u in ug.DefaultIfEmpty()
                        join eea in _dbContext.EventoEstadoAcao on e.Evento1 equals eea.CodigoEvento into eeag
                        from eea in eeag.DefaultIfEmpty()
                        select new
                        {
                            Evento = e,
                            Cliente = c,
                            Receptora = r,
                            Monitoramento = em,
                            Usuario = u,
                            EventoEstado = eea
                        };

            // Only events that had an attendance record (performed attendimentos)
            //query = query.Where(x => x.Monitoramento != null);

            // Apply filters
            if (viewModel.Filtros.ReceptoraId.HasValue)
            {
                query = query.Where(x => x.Receptora.IdReceptora == viewModel.Filtros.ReceptoraId.Value);
            }

            if (!string.IsNullOrWhiteSpace(viewModel.Filtros.CodigoCliente))
            {
                query = query.Where(x => x.Cliente.Codigo.Contains(viewModel.Filtros.CodigoCliente));
            }

            if (!string.IsNullOrWhiteSpace(viewModel.Filtros.NumeroChip))
            {
                query = query.Where(x => x.Cliente.TelefoneContato != null && x.Cliente.TelefoneContato.Contains(viewModel.Filtros.NumeroChip));
            }

            if (!string.IsNullOrWhiteSpace(viewModel.Filtros.NomeCliente))
            {
                query = query.Where(x => x.Cliente.Nome.Contains(viewModel.Filtros.NomeCliente));
            }

            if (viewModel.Filtros.TipoEventos != null && viewModel.Filtros.TipoEventos.Any())
            {
                // filter by event code (Evento.Evento1)
                
                query = query.Where(x => viewModel.Filtros.TipoEventos.Contains(x.Evento.Evento1));
            }

            if (viewModel.Filtros.DataInicial.HasValue)
            {
                query = query.Where(x => x.Evento.DataHora >= viewModel.Filtros.DataInicial.Value);
            }
            if (viewModel.Filtros.DataFinal.HasValue)
            {
                query = query.Where(x => x.Evento.DataHora <= viewModel.Filtros.DataFinal.Value);
            }

            var result = await query
                .OrderByDescending(x => x.Evento.DataHora)
                .Select(x => new RelatorioAtendimentoItemViewModel
                {
                    DataEvento = x.Evento.DataHora,
                    Receptora = x.Receptora.Nome,
                    CodigoEvento = x.Evento.Evento1,
                    DescricaoEvento = x.EventoEstado != null ? x.EventoEstado.Decricao : null,
                    CodigoCliente = x.Cliente.Codigo,
                    NomeCliente = x.Cliente.Nome,
                    DescricaoAtendimento = x.Monitoramento != null ? x.Monitoramento.DescricaoMonitoramento:"",
                    NomeAtendente = x.Usuario != null ? x.Usuario.Nome : null,
                    DataInicioAtendimento = x.Monitoramento != null ? x.Monitoramento.DataHoraInicio: null,
                    DataFimAtendimento = x.Monitoramento != null ? x.Monitoramento.DataHoraTermino: null,
                    TempoAtendimento = x.Monitoramento != null ? ((x.Monitoramento.DataHoraInicio.HasValue && x.Monitoramento.DataHoraTermino.HasValue)? 
                        (x.Monitoramento.DataHoraTermino.Value - x.Monitoramento.DataHoraInicio.Value)
                        : (TimeSpan?)null): null
                })
                .Take(10000)
                .ToListAsync();

            return result;
        }

        [HttpPost]
        public async Task<IActionResult> ExportarExcelAsync(RelatorioAtendimentoViewModel viewModel)
        {
            var itens = await ConsultaAtendimentosAsync(viewModel);

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Atendimentos");

            // Headers
            worksheet.Cell(1, 1).Value = "DataHoraEvento";
            worksheet.Cell(1, 2).Value = "Receptora";
            worksheet.Cell(1, 3).Value = "CodigoEvento";
            worksheet.Cell(1, 4).Value = "DescricaoEvento";
            worksheet.Cell(1, 5).Value = "CodigoCliente";
            worksheet.Cell(1, 6).Value = "NomeCliente";
            worksheet.Cell(1, 7).Value = "DescricaoAtendimento";
            worksheet.Cell(1, 8).Value = "NomeAtendente";
            worksheet.Cell(1, 9).Value = "DataHoraInicio";
            worksheet.Cell(1, 10).Value = "DataHoraFim";
            worksheet.Cell(1, 11).Value = "TempoAtendimento";

            for (int i = 0; i < itens.Count; i++)
            {
                var r = itens[i];
                worksheet.Cell(i + 2, 1).Value = r.DataEvento;
                worksheet.Cell(i + 2, 2).Value = r.Receptora;
                worksheet.Cell(i + 2, 3).Value = r.CodigoEvento;
                worksheet.Cell(i + 2, 4).Value = r.DescricaoEvento;
                worksheet.Cell(i + 2, 5).Value = r.CodigoCliente;
                worksheet.Cell(i + 2, 6).Value = r.NomeCliente;
                worksheet.Cell(i + 2, 7).Value = r.DescricaoAtendimento;
                worksheet.Cell(i + 2, 8).Value = r.NomeAtendente;
                worksheet.Cell(i + 2, 9).Value = r.DataInicioAtendimento;
                worksheet.Cell(i + 2, 10).Value = r.DataFimAtendimento;
                worksheet.Cell(i + 2, 11).Value = r.TempoAtendimento.HasValue ? r.TempoAtendimento.Value.ToString(@"dd\:hh\:mm\:ss") : "";
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            var content = stream.ToArray();

            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                $"RelatorioAtendimentos_{DateTime.UtcNow.AddHours(-3):yyMMdd_HHmmss}.xlsx");
        }
    }

    public class RelatorioAtendimentoViewModel
    {
        public RelatorioAtendimentoViewModel()
        {
            Itens = new List<RelatorioAtendimentoItemViewModel>();
            Filtros = new RelatorioAtendimentoFiltrosViewModel();
        }

        public List<RelatorioAtendimentoItemViewModel> Itens { get; set; }
        public RelatorioAtendimentoFiltrosViewModel Filtros { get; set; }
    }

    public class RelatorioAtendimentoItemViewModel
    {
        public DateTime? DataEvento { get; set; }
        public string Receptora { get; set; }
        public string CodigoEvento { get; set; }
        public string DescricaoEvento { get; set; }
        public string CodigoCliente { get; set; }
        public string NomeCliente { get; set; }
        public string DescricaoAtendimento { get; set; }
        public string NomeAtendente { get; set; }
        public DateTime? DataInicioAtendimento { get; set; }
        public DateTime? DataFimAtendimento { get; set; }
        public TimeSpan? TempoAtendimento { get; set; }
    }

    public class RelatorioAtendimentoFiltrosViewModel
    {
        public int? ReceptoraId { get; set; }
        public string CodigoCliente { get; set; }
        public string NumeroChip { get; set; }
        public string NomeCliente { get; set; }
        public List<string> TipoEventos { get; set; } = new List<string>();
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        public bool ExportaExcel { get; set; }
    }
}