using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class ReceptoraMonitoramento
    {
        public int IdReceptoraMonitoramento { get; set; }
        public string DescricaoReceptora { get; set; }
        public bool? AtivoReceptoraMonitoramento { get; set; }
    }
}
