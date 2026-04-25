using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class CustoExtra
    {
        public int IdCustoExtra { get; set; }
        public int IdUsuario { get; set; }
        public string DescricaoCusto { get; set; }
        public string Valor { get; set; }
        public string Documento { get; set; }
        public DateTime? DataCadstro { get; set; }
    }
}
