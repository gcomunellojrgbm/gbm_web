using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class ClienteArmadoPeriodo
    {
        public int IdClienteArmadoPeriodo { get; set; }
        public string Conta { get; set; }
        public string DiaSemana { get; set; }
        public string HoraInicio { get; set; }
        public string HoraTemino { get; set; }
        public bool? AtivoArmadoPeriodo { get; set; }
    }
}
