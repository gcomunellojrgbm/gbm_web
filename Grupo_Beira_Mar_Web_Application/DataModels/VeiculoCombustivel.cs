using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class VeiculoCombustivel
    {
        public int IdVeiculoCombustivel { get; set; }
        public int IdVeiculo { get; set; }
        public string KmVeiculo { get; set; }
        public double? QtdCombustivel { get; set; }
        public double? CustoCombustivel { get; set; }
        public DateTime? DataCombustivel { get; set; }
    }
}
