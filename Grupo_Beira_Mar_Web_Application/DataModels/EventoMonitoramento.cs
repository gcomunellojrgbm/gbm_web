using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class EventoMonitoramento
    {
        public int IdEventoMonitoramento { get; set; }
        public int IdEvento { get; set; }
        public int? IdUsuario { get; set; }
        public bool? Atendimento { get; set; }
        public bool? Concluido { get; set; }
        public bool? Ativo { get; set; }
        public DateTime? DataHoraInicio { get; set; }
        public DateTime? DataHoraTermino { get; set; }
        public string DescricaoMonitoramento { get; set; }
        public int? IdReceptora { get; set; }

        public virtual Usuario Usuario { get; set; } // Para o IdUsuario
        //public virtual Evento Evento { get; set; } // Para o IdEvento
    }
}
