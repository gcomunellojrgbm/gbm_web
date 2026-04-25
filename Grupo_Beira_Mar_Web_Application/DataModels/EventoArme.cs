using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class EventoArme
    {
        public int IdEventoArme { get; set; }
        public int? IdFormato { get; set; }
        public int? IdReceptora { get; set; }
        public string Conta { get; set; }
        public bool? Armado { get; set; }
        public DateTime? DataHora { get; set; }
    }
}
