using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class Aniversario
    {
        public int IdAniversario { get; set; }
        public string Nome { get; set; }
        public string Data { get; set; }
        public string Ano { get; set; }
        public string Contato { get; set; }
        public bool? Ativo { get; set; }
    }
}
