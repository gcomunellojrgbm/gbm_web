using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class VeiculoGestao
    {
        public int IdVeiculoGestao { get; set; }
        public int IdVeiculo { get; set; }
        public int IdUsuario { get; set; }
        public string KmInical { get; set; }
        public string KmFinal { get; set; }
        public string NivelCombustivel { get; set; }
        public string DescricaoAtividade { get; set; }
        public DateTime? DataSaida { get; set; }
        public DateTime? DataChegada { get; set; }
        public int? IdBaseSaida { get; set; }
        public int? IdBaseRetorno { get; set; }
        public bool? Monitoramento { get; set; }
        public int? IdEventoMonit { get; set; }
    }
}
