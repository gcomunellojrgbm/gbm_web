using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class Manutencao
    {
        public int IdManutencao { get; set; }
        public int IdUsuarioCad { get; set; }
        public string Conta { get; set; }
        public int? IdTipoManutencao { get; set; }
        public DateTime? DataManutencao { get; set; }
        public string DescricaoManutencao { get; set; }
        public string ValorCobrado { get; set; }
        public string ValorPagamento { get; set; }
        public string FormaPagamento { get; set; }
        public string DocPagamento { get; set; }
        public string ReciboPagamento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public bool? ConcluidoManutencao { get; set; }
        public bool? Pendente { get; set; }
        public bool? AtivoManutencao { get; set; }
        public bool? Radio { get; set; }
        public bool? Discadora { get; set; }
        public bool? Gprs { get; set; }
        public bool? Central { get; set; }
        public bool? Bateria { get; set; }
        public bool? Magnetos { get; set; }
        public bool? Fios { get; set; }
        public bool? Sirene { get; set; }
        public bool? Sensores { get; set; }
        public bool? Controle { get; set; }
    }
}
