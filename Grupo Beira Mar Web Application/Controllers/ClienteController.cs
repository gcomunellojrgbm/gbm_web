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
using System.Threading.Tasks;


namespace Grupo_Beira_Mar_Web_Application.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public ClienteController(
            ILogger<HomeController> logger,
            ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var clientes = await _dbContext.Cliente.ToListAsync();
            return View(clientes);
        }

        public async Task<IActionResult> Create(int? id)
        {
            var model = new ClienteViewModel();
            model.TiposCliente = await _dbContext.TipoCliente
                .Select(t => new SelectListItem
                {
                    Value = t.IdTipoCliente.ToString(),
                    Text = t.Tipocliente1
                }).ToListAsync();

            if (id.HasValue)
            {
                var cliente = await _dbContext.Cliente.FindAsync(id);
                var detalhe = await _dbContext.DetalheCliente
                    .FirstOrDefaultAsync(x => x.IdCliente == id);

                if (cliente != null)
                {
                    model.IdCliente = cliente.IdCliente;
                    model.Codigo = cliente.Codigo;
                    model.Nome = cliente.Nome;
                    model.Estado = cliente.Estado;
                    model.Cidade = cliente.Cidade;
                    model.Bairro = cliente.Bairro;
                    model.Logadouro = cliente.Logadouro;
                    model.Complemento = cliente.Complemento;
                    model.Cep = cliente.Cep;
                    model.NomeContato = cliente.NomeContato;
                    model.TelefoneContato = cliente.TelefoneContato;
                    model.EmailContato = cliente.EmailContato;
                    model.ProximidadeContato = cliente.ProximidadeContato;
                    model.ObsContato = cliente.ObsContato;
                    model.Ativo = (cliente.Ativo.HasValue)? cliente.Ativo.Value: false;
                    model.Inadimplente = (cliente.Inadimplente.HasValue)? cliente.Inadimplente.Value: false;

                    if (detalhe != null)
                    {
                        model.Autorizacao = detalhe.Autorizacao;
                        model.SenhaContra = detalhe.SenhaContra;
                        model.Senha = detalhe.Senha;
                        model.Chaves = detalhe.Chaves;
                        model.Telefone2 = detalhe.Telefone2;
                        model.Telefone3 = detalhe.Telefone3;
                        model.DataCadastro = detalhe.DataCadastro;
                        model.IdTipoCliente = detalhe.IdTipoCliente;
                        model.Endereco2 = detalhe.Endereco2;
                        model.Cidade2 = detalhe.Cidade2;
                        model.Cpf = detalhe.Cpf;
                    }
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.TiposCliente = await _dbContext.TipoCliente
                    .Select(t => new SelectListItem
                    {
                        Value = t.IdTipoCliente.ToString(),
                        Text = t.Tipocliente1
                    }).ToListAsync();
                return View(model);
            }

            Cliente cliente;
            DetalheCliente detalhe;

            if (model.IdCliente.HasValue)
            {
                cliente = await _dbContext.Cliente.FindAsync(model.IdCliente);
                detalhe = await _dbContext.DetalheCliente
                    .FirstOrDefaultAsync(x => x.IdCliente == model.IdCliente);
            }
            else
            {
                cliente = new Cliente();
                detalhe = new DetalheCliente();
                _dbContext.Cliente.Add(cliente);
                _dbContext.DetalheCliente.Add(detalhe);
            }

            // Cliente
            cliente.Codigo = model.Codigo;
            cliente.Nome = model.Nome;
            cliente.Estado = model.Estado;
            cliente.Cidade = model.Cidade;
            cliente.Bairro = model.Bairro;
            cliente.Logadouro = model.Logadouro;
            cliente.Complemento = model.Complemento;
            cliente.Cep = model.Cep;
            cliente.NomeContato = model.NomeContato;
            cliente.TelefoneContato = model.TelefoneContato;
            cliente.EmailContato = model.EmailContato;
            cliente.ProximidadeContato = model.ProximidadeContato;
            cliente.ObsContato = model.ObsContato;
            cliente.Ativo = model.Ativo;
            cliente.Inadimplente = model.Inadimplente;

            await _dbContext.SaveChangesAsync(); // salva para obter IdCliente se novo

            // DetalheCliente
            detalhe.IdCliente = cliente.IdCliente;
            detalhe.Autorizacao = model.Autorizacao;
            detalhe.SenhaContra = model.SenhaContra;
            detalhe.Senha = model.Senha;
            detalhe.Chaves = model.Chaves;
            detalhe.Telefone2 = model.Telefone2;
            detalhe.Telefone3 = model.Telefone3;
            detalhe.DataCadastro = model.DataCadastro;
            detalhe.IdTipoCliente = model.IdTipoCliente;
            detalhe.Endereco2 = model.Endereco2;
            detalhe.Cidade2 = model.Cidade2;
            detalhe.Cpf = model.Cpf;

            await _dbContext.SaveChangesAsync();

            TempData["SuccessMessage"] = "Cliente salvo com sucesso!";
            return RedirectToAction("Index");
        }

    }
}
