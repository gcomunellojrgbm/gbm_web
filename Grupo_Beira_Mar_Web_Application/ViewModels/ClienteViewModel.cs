using System;
using System.ComponentModel.DataAnnotations;
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
        [StringLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        public string Codigo { get; set; }
        [StringLength(2, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        public string Particao { get; set; }
        [StringLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        public string Nome { get; set; }
        [StringLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        public string Estado { get; set; }
        [StringLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        public string Cidade { get; set; }
        [StringLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        public string Bairro { get; set; }
        [StringLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        public string Logadouro { get; set; }
        [StringLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        public string Complemento { get; set; }
        [StringLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        public string Cep { get; set; }
        [StringLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        public string NomeContato { get; set; }
        [StringLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        public string TelefoneContato { get; set; }
        [StringLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        public string EmailContato { get; set; }
        [StringLength(200, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
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
        [StringLength(12, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        public string DataCadastro { get; set; }
        public int? IdTipoCliente { get; set; }
        public string Endereco2 { get; set; }
        public string Cidade2 { get; set; }
        public string Cpf { get; set; }

        // Dropdown
        public List<SelectListItem> TiposCliente { get; set; }
        public List<SelectListItem> Receptora { get; set; }
        public int IdReceptora { get; set; }
    }
}
