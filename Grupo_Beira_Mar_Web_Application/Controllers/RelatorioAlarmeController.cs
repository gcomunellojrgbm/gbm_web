using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Grupo_Beira_Mar_Web_Application.Models;
using Grupo_Beira_Mar_Web_Application.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OfficeOpenXml;
using System.IO;
using ClosedXML.Excel;
using System;
using Grupo_Beira_Mar_Web_Application.ViewModels;

namespace Grupo_Beira_Mar_Web_Application.Controllers
{
    public class RelatorioAlarmeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RelatorioAlarmeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [HttpPost]
        public IActionResult Index(
            RelatorioAlarmeViewModel viewModel
            //,            string nome, string numeroChip, string emailContato, string status
            )
        {
            List<RelatorioAlarmeItemViewModel> alarmes = ConsultaAlarmes(viewModel);

            if ((bool)(viewModel.Filtros?.ExportaExcel))
            {
                using var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Alarmes");

                // Cabeçalhos
                worksheet.Cell(1, 1).Value = "Data";
                worksheet.Cell(1, 2).Value = "Código";
                worksheet.Cell(1, 3).Value = "Nome";
                worksheet.Cell(1, 4).Value = "Endereço";
                worksheet.Cell(1, 5).Value = "NumeroChip";

                // Dados
                for (int i = 0; i < alarmes.Count; i++)
                {
                    var c = alarmes[i];
                    worksheet.Cell(i + 2, 1).Value = c.DataEvento;
                    worksheet.Cell(i + 2, 2).Value = c.Codigo;
                    worksheet.Cell(i + 2, 3).Value = c.Nome;
                    worksheet.Cell(i + 2, 4).Value = c.Endereco;
                    worksheet.Cell(i + 2, 5).Value = c.NumeroChip;
                }

                using var stream = new MemoryStream();
                workbook.SaveAs(stream);
                var content = stream.ToArray();
                
                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"RelatorioAlarmes_{DateTime.UtcNow.AddHours(-3).ToString("yyMMdd_HHmmss")}.xlsx");
            }
            else
            {

                viewModel = new RelatorioAlarmeViewModel()
                {
                    Alarmes = alarmes,
                    Filtros = new RelatorioAlarmeFiltrosViewModel()
                    {
                        Codigo = viewModel.Filtros?.Codigo,
                        Nome = viewModel.Filtros?.Nome,
                        Endereco = viewModel.Filtros?.Endereco,

                        NumeroChip = viewModel.Filtros?.NumeroChip,
                        DataInicial = viewModel.Filtros?.DataInicial,
                        DataFinal = viewModel.Filtros?.DataFinal,
                        Status = viewModel.Filtros?.Status,
                    }
                };

                return View(viewModel);
            }
        }

        private List<RelatorioAlarmeItemViewModel> ConsultaAlarmes(RelatorioAlarmeViewModel viewModel)
        {
            //var query = _context.Cliente.AsQueryable();


            var query = (from e in _context.Evento
                                    // LEFT JOIN com ClienteMonitoramento via 'Conta'
                                join cm in _context.ClienteMonitoramento on e.Conta equals cm.Conta into cmGroup
                                from cm in cmGroup.DefaultIfEmpty() // DefaultIfEmpty para LEFT JOIN
                                                                    // LEFT JOIN com Cliente via 'IdCliente' de ClienteMonitoramento
                                join c in _context.Cliente on e.Conta equals c.Codigo into cGroup
                                from c in cGroup//.DefaultIfEmpty() // DefaultIfEmpty para LEFT JOIN
                                 orderby e.DataHora descending
                                 select new EventoIndexViewModel
                                 {
                                     IdEvento = e.IdEvento,
                                     NumeroEvento = e.IdEvento,
                                     Conta = e.Conta,
                                     NomeCliente = c.Nome, // Obtém o nome do cliente através do join
                                     Endereco = (c.Logadouro + ", " + c.Bairro + ", " + c.Cidade + " - " + c.Estado),
                                     NumeroChip = c.TelefoneContato,
                                     DataEvento = e.DataHora,
                                     TipoEvento = e.Evento1, // Mapeado para Tipo Evento na tela
                                     Grupo = e.Grupo,
                                     Zona = e.Zona

                                 }
                        )
                     //.Take(1000) // Limita para fins de demonstração e performance
                     .AsQueryable();



            if (!string.IsNullOrEmpty(viewModel.Filtros?.Codigo))
            {
                query = query.Where(c => c.Conta.Contains(viewModel.Filtros.Codigo));
            }

            if (!string.IsNullOrEmpty(viewModel.Filtros?.Nome))
            {
                query = query.Where(c => c.NomeCliente.Contains(viewModel.Filtros.Nome));
            }

            if (!string.IsNullOrEmpty(viewModel.Filtros?.Endereco))
            {
                query = query.Where(c => c.Endereco.Contains(viewModel.Filtros.Endereco));
            }

            if (!string.IsNullOrEmpty(viewModel.Filtros?.NumeroChip))
            {
                query = query.Where(c => c.NumeroChip.Contains(viewModel.Filtros.NumeroChip));
            }

            if ((bool)(viewModel.Filtros?.DataInicial.HasValue))
            {
                query = query.Where(c => c.DataEvento >= viewModel.Filtros.DataInicial.Value);
            }
            if ((bool)(viewModel.Filtros?.DataFinal.HasValue))
            {
                query = query.Where(c => c.DataEvento.Value.Date <= viewModel.Filtros.DataFinal.Value);
            }


            var clientes = query
                .Select(c => new RelatorioAlarmeItemViewModel
                {
                    //IdCliente = c.Conta,
                    IdEvento = c.IdEvento,
                    Codigo = c.Conta,
                    Nome = c.NomeCliente,
                    Endereco = c.Endereco,
                    NumeroChip = c.NumeroChip,
                    DataEvento = c.DataEvento
                    //EmailContato = c.EmailContato,
                    //Ativo = c.Ativo,
                    //Status = (bool)c.Ativo ? "Ativo" : "Inativo"
                })
                .OrderByDescending(c => c.DataEvento)
                .Take(10000)
                .ToList();

            return clientes;
        }



        public IActionResult ExportarExcel(RelatorioAlarmeViewModel viewModel)
        {
            List<RelatorioAlarmeItemViewModel> clientes = ConsultaAlarmes(viewModel);

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Clientes");

            // Cabeçalhos
            worksheet.Cell(1, 1).Value = "Código";
            worksheet.Cell(1, 2).Value = "Nome";
            worksheet.Cell(1, 3).Value = "Endereço";
            worksheet.Cell(1, 4).Value = "NumeroChip";
            worksheet.Cell(1, 5).Value = "Email";
            worksheet.Cell(1, 6).Value = "Status";

            // Dados
            for (int i = 0; i < clientes.Count; i++)
            {
                var c = clientes[i];
                worksheet.Cell(i + 2, 1).Value = c.Codigo;
                worksheet.Cell(i + 2, 2).Value = c.Nome;
                worksheet.Cell(i + 2, 3).Value = c.Endereco;
                worksheet.Cell(i + 2, 4).Value = c.NumeroChip;
                worksheet.Cell(i + 2, 5).Value = c.EmailContato;
                worksheet.Cell(i + 2, 6).Value = c.Ativo == true ? "Ativo" : "Inativo";
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            var content = stream.ToArray();

            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "RelatorioAlarmes.xlsx");
        }

    }

    public class RelatorioAlarmeViewModel
    {
        public RelatorioAlarmeViewModel()
        {
            Alarmes = new List<RelatorioAlarmeItemViewModel>();
            Filtros = new RelatorioAlarmeFiltrosViewModel();
        }
        public List<RelatorioAlarmeItemViewModel> Alarmes { get; set; }
        public RelatorioAlarmeFiltrosViewModel Filtros { get; set; }
    }

    public class RelatorioAlarmeItemViewModel
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string NumeroChip { get; set; }
        public string EmailContato { get; set; }
        public string Status { get; set; }

        public RelatorioAlarmeFiltrosViewModel Filtros { get; set; }
        public string Codigo { get; set; }
        public bool? Ativo { get; set; }
        public DateTime? DataEvento { get; set; }
        public int IdEvento { get; set; }
    }

    public class RelatorioAlarmeFiltrosViewModel
    {
        
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        
        public string NumeroChip { get;  set; }
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        public AlarmeStatusType? Status { get;  set; }
        public bool ExportaExcel { get; set; }
    }

    public enum AlarmeStatusType
    {
        [Display(Name = "Ativo")]
        Ativo,
        [Display(Name = "Inativo")]
        Inativo
    }
}