using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class TipoEvento
    {
        public int IdTipoEvento { get; set; }
        public int? EvtRest { get; set; }
        public string Evento { get; set; }
        public string Grupo { get; set; }
        public string Zona { get; set; }
        public int? IdFormato { get; set; }
        public string Descricao { get; set; }
        public string DescricaoZona { get; set; }
        public bool? AtendimentoManual { get; set; }
        public bool? TocarSom { get; set; }
        public bool? Ativo { get; set; }
    }
}
