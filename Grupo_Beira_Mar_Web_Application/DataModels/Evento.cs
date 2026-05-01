using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class Evento
    {
        public int IdEvento { get; set; }
        public string Conta { get; set; }
        public int? EvtRest { get; set; }
        public string Evento1 { get; set; }
        public string Grupo { get; set; }
        public string Zona { get; set; }
        public int? IdFormato { get; set; }
        public string SinalCelular { get; set; }
        public string TipoRede { get; set; }
        public DateTime? DataHora { get; set; }
        public int? IdReceptora { get; set; }
        public int? QtdEventos { get; set; }
        public int? IdCliente { get; set; }
    }
}
