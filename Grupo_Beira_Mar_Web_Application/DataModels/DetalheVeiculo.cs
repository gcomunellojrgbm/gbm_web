using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class DetalheVeiculo
    {
        public int IdDetalheVeiculo { get; set; }
        public int IdVeiculo { get; set; }
        public string KmAtual { get; set; }
        public string NivelCombustivel { get; set; }
        public string Autonomia { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAtual { get; set; }
        public bool? Ativo { get; set; }
    }
}
