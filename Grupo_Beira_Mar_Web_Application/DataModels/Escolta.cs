using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class Escolta
    {
        public int IdEscolta { get; set; }
        public int IdUsuarioCad { get; set; }
        public string Conta { get; set; }
        public string LocalInicio { get; set; }
        public string LocalTermino { get; set; }
        public DateTime? DataEscolta { get; set; }
        public string ValorPatrimonio { get; set; }
        public string ValorCobrado { get; set; }
        public string ValorPagamento { get; set; }
        public string FormaPagamento { get; set; }
        public string DocPagamento { get; set; }
        public string ReciboPagamento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public bool? ConcluidoEscolta { get; set; }
        public bool? Pendente { get; set; }
        public bool? AtivoEscolta { get; set; }
    }
}
