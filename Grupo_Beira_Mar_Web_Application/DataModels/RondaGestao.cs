using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class RondaGestao
    {
        public int IdRondaGestao { get; set; }
        public int IdRonda { get; set; }
        public int IdUsuario { get; set; }
        public int IdVeiculo { get; set; }
        public DateTime? DataGestao { get; set; }
        public int? QuantidadeTrajetos { get; set; }
        public bool? Concluido { get; set; }
    }
}
