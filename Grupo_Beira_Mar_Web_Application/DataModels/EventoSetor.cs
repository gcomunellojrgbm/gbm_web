using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class EventoSetor
    {
        public int IdEventoSetor { get; set; }
        public int? IdFormato { get; set; }
        public string Conta { get; set; }
        public string Evento { get; set; }
        public string Grupo { get; set; }
        public string Zona { get; set; }
        public string DescricaoSetor { get; set; }
        public bool? AtivoSetor { get; set; }
    }
}
