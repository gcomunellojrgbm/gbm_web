using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class RondaGestaoDetalhe
    {
        public int IdRondaGestaoDetalhe { get; set; }
        public int IdRondaGestao { get; set; }
        public DateTime? DataInicial { get; set; }
        public DateTime? DataTermino { get; set; }
        public string DescricaoDetalhe { get; set; }
    }
}
