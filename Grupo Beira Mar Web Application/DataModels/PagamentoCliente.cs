using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class PagamentoCliente
    {
        public int IdPagamentoCliente { get; set; }
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public int IdTipoServico { get; set; }
        public string ValorCobrado { get; set; }
        public string ValorPagamento { get; set; }
        public string FormaPagamento { get; set; }
        public string DocPagamento { get; set; }
        public string ReciboPagamento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public bool? Pendente { get; set; }
    }
}
