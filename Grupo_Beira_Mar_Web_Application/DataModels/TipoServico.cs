using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class TipoServico
    {
        public int IdTipoServico { get; set; }
        public string Descricao { get; set; }
        public string Obs { get; set; }
        public bool? Ativo { get; set; }
    }
}
