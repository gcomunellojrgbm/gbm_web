using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.WebPages.Html;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Grupo_Beira_Mar_Web_Application.ViewModels
{
    public class ClienteViewModel
    {
        // Cliente
        public int? IdCliente { get; set; }
        public string Codigo { get; set; }
        public string Particao { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Logadouro { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string NomeContato { get; set; }
        public string TelefoneContato { get; set; }
        public string EmailContato { get; set; }
        public string ProximidadeContato { get; set; }
        public string ObsContato { get; set; }
        public bool Ativo { get; set; }
        public bool Inadimplente { get; set; }

        // DetalheCliente
        public string Autorizacao { get; set; }
        public string SenhaContra { get; set; }
        public string Senha { get; set; }
        public string Chaves { get; set; }
        public string Telefone2 { get; set; }
        public string Telefone3 { get; set; }
        public string DataCadastro { get; set; }
        public int? IdTipoCliente { get; set; }
        public string Endereco2 { get; set; }
        public string Cidade2 { get; set; }
        public string Cpf { get; set; }

        // Dropdown
        public List<SelectListItem> TiposCliente { get; set; }
        
    }
}
