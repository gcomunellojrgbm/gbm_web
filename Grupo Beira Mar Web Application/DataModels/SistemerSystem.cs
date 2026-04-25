using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class SistemerSystem
    {
        public int IdSistemerSystem { get; set; }
        public int? Aplicacao { get; set; }
        public string DataInicial { get; set; }
        public string DataFinal { get; set; }
        public string TimerLic { get; set; }
        public string Licensa { get; set; }
        public string Ativo { get; set; }
    }
}
