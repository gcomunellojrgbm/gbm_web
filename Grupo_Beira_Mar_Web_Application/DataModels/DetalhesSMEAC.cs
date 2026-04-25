using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class DetalhesSMEAC
    {
        public int IdDetalhesSMEAC { get; set; }
        public int IdSMEAC { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdVeiculo { get; set; }
        public string DescricaoDetalhe { get; set; }
        public DateTime? DataDetalheChegada { get; set; }
        public DateTime? DataDetalheSaida { get; set; }

        //public virtual SMEAC SMEAC { get; set; } // Para o IdSMEAC
        public virtual Usuario Usuario { get; set; } // Para o IdUsuario (Vigilante Campo)
        public virtual Veiculo Veiculo { get; set; } // Para o IdVeiculo (Veículo Atendimento)
    }
}
