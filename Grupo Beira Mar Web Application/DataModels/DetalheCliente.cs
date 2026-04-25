using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class DetalheCliente
    {
        public int IdDetalheCliente { get; set; }
        public int IdCliente { get; set; }
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
    }
}
