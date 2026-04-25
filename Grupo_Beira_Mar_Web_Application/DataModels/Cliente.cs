using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class Cliente
    {
        public int IdCliente { get; set; }
        public string Codigo { get; set; }
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
        public bool? Ativo { get; set; }
        public bool? Inadimplente { get; set; }
    }
}
