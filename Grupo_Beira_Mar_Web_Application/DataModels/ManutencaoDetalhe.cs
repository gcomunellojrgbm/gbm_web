using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class ManutencaoDetalhe
    {
        public int IdManutencaoDetalhe { get; set; }
        public int IdManutencao { get; set; }
        public int IdUsuarioManutencao { get; set; }
        public int IdVeiculo { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public string DescricaoManutencaoDetalhe { get; set; }
        public bool? ConcluidoDetalhe { get; set; }
    }
}
