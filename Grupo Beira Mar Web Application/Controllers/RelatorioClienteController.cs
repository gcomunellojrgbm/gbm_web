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

namespace Grupo_Beira_Mar_Web_Application.Controllers
{
    public class RelatorioClienteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RelatorioClienteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [HttpPost]
        public IActionResult Index(
            RelatorioClienteViewModel viewModel
            //,            string nome, string numeroChip, string emailContato, string status
            )
        {
            List<RelatorioClienteItemViewModel> clientes = ConsultaClientes(viewModel);

            if ((bool)(viewModel.Filtros?.ExportaExcel))
            {
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
                
                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"RelatorioClientes_{DateTime.UtcNow.AddHours(-3).ToString("yyMMdd_HHmmss")}.xlsx");
            }
            else
            {

                viewModel = new RelatorioClienteViewModel()
                {
                    Clientes = clientes,
                    Filtros = new RelatorioClienteFiltrosViewModel()
                    {
                        Codigo = viewModel.Filtros?.Codigo,
                        Nome = viewModel.Filtros?.Nome,
                        Endereco = viewModel.Filtros?.Endereco,

                        NumeroChip = viewModel.Filtros?.NumeroChip,
                        EmailContato = viewModel.Filtros?.EmailContato,
                        Status = viewModel.Filtros?.Status,
                    }
                };

                return View(viewModel);
            }
        }

        private List<RelatorioClienteItemViewModel> ConsultaClientes(RelatorioClienteViewModel viewModel)
        {
            var query = _context.Cliente.AsQueryable();
            var hasFiltro = false;

            if (!string.IsNullOrEmpty(viewModel.Filtros?.Codigo))
            {
                query = query.Where(c => c.Codigo.Contains(viewModel.Filtros.Codigo));
                hasFiltro = true;
            }

            if (!string.IsNullOrEmpty(viewModel.Filtros?.Nome))
            {
                query = query.Where(c => c.Nome.Contains(viewModel.Filtros.Nome));
                hasFiltro = true;
            }

            if (!string.IsNullOrEmpty(viewModel.Filtros?.Endereco))
            {
                query = query.Where(c => (c.Logadouro + ", " + c.Bairro + ", " + c.Cidade + " - " + c.Estado).Contains(viewModel.Filtros.Endereco));
                hasFiltro = true;
            }

            if (!string.IsNullOrEmpty(viewModel.Filtros?.NumeroChip))
            {
                query = query.Where(c => c.TelefoneContato.Contains(viewModel.Filtros.NumeroChip));
                hasFiltro = true;
            }

            if (!string.IsNullOrEmpty(viewModel.Filtros?.EmailContato))
            {
                query = query.Where(c => c.EmailContato.Contains(viewModel.Filtros.EmailContato));
                hasFiltro = true;
            }

            if ((bool)(viewModel.Filtros?.Status.HasValue))
            {
                bool ativo = (viewModel.Filtros.Status == StatusType.Ativo);
                query = query.Where(c => c.Ativo == ativo);
                hasFiltro = true;
            }

            var clientes = query
                .Select(c => new RelatorioClienteItemViewModel
                {
                    IdCliente = c.IdCliente,
                    Codigo = c.Codigo,
                    Nome = c.Nome,
                    Endereco = c.Logadouro + ", " + c.Bairro + ", " + c.Cidade + " - " + c.Estado,
                    NumeroChip = c.TelefoneContato,
                    EmailContato = c.EmailContato,
                    Ativo = c.Ativo,
                    Status = (bool)c.Ativo ? "Ativo" : "Inativo"
                })
                .OrderByDescending(c => c.IdCliente)
                //.Take(!hasFiltro ? 1000 : 1000000)
                .ToList();
            return clientes;
        }

        public IActionResult ExportarExcel(RelatorioClienteViewModel viewModel)
        {
            List<RelatorioClienteItemViewModel> clientes = ConsultaClientes(viewModel);

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

            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "RelatorioClientes.xlsx");
        }

    }

    public class RelatorioClienteViewModel
    {
        public RelatorioClienteViewModel()
        {
            Clientes = new List<RelatorioClienteItemViewModel>();
            Filtros = new RelatorioClienteFiltrosViewModel();
        }
        public List<RelatorioClienteItemViewModel> Clientes { get; set; }
        public RelatorioClienteFiltrosViewModel Filtros { get; set; }
    }

    public class RelatorioClienteItemViewModel
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string NumeroChip { get; set; }
        public string EmailContato { get; set; }
        public string Status { get; set; }

        public RelatorioClienteFiltrosViewModel Filtros { get; set; }
        public string Codigo { get; set; }
        public bool? Ativo { get; set; }
    }

    public class RelatorioClienteFiltrosViewModel
    {
        
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        
        public string NumeroChip { get;  set; }
        public string EmailContato { get;  set; }
        public StatusType? Status { get;  set; }
        public bool ExportaExcel { get; set; }
    }

    public enum StatusType
    {
        [Display(Name = "Ativo")]
        Ativo,
        [Display(Name = "Inativo")]
        Inativo
    }
}