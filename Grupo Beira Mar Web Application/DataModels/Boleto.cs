using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class Boleto
    {
        public int IdBoleto { get; set; }
        public int IdCarneBoleto { get; set; }
        public string Codigo { get; set; }
        public string Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public bool? AtivoBoleto { get; set; }
        public bool? Pendente { get; set; }
        public bool? Atrasado { get; set; }
    }
}
