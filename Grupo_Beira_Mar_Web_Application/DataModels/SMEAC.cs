using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class SMEAC
    {
        public int IdSMEAC { get; set; }
        public int? IdEventoMonitoramento { get; set; }
        public DateTime? DataSolInicio { get; set; }
        public DateTime? DataSolTermino { get; set; }
        public bool? ConcluidoSol { get; set; }

        //public virtual EventoMonitoramento EventoMonitoramento { get; set; } // Para o IdEventoMonitoramento
        //public virtual ICollection<DetalhesSMEAC> DetalhesSMEAC { get; set; } // Para a lista de detalhes
    }
}
