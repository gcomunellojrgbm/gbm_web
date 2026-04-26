using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class DiarioBordo
    {
        public int IdDiarioBordo { get; set; }
        public int? IdUsuario { get; set; }
        public string Descricao { get; set; }
        public DateTime? Data { get; set; }
        public bool? Concluido { get; set; }
        public string Conta { get; set; }
    }
}
