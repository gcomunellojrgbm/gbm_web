using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class InspecaoVeiculo
    {
        public int IdInspecaoVeiculo { get; set; }
        public int IdVeiculo { get; set; }
        public int IdUsuario { get; set; }
        public string Descricao { get; set; }
        public string Km { get; set; }
        public DateTime? DataCadstro { get; set; }
        public bool? Ativo { get; set; }
    }
}
