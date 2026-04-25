using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class EventoArmePeriodo
    {
        public int IdEventoArmePeriodo { get; set; }
        public int? IdEvento { get; set; }
        public string Conta { get; set; }
        public DateTime? DataHora { get; set; }
        public bool? Isarmado { get; set; }
        public bool? Isvisivel { get; set; }
    }
}
