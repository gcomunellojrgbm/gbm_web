using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class CarneBoleto
    {
        public int IdCarneBoleto { get; set; }
        public int IdCliente { get; set; }
        public string Tag { get; set; }
        public string TipoServico { get; set; }
        public DateTime DataCadastro { get; set; }
        public string DescricaoCarne { get; set; }
        public bool? Ativo { get; set; }
        public bool? Quitado { get; set; }
    }
}
