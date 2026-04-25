using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class Veiculo
    {
        public int IdVeiculo { get; set; }
        public int IdTipoVeiculo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Ano { get; set; }
        public string Potencia { get; set; }
        public string Cor { get; set; }
        public string Portas { get; set; }
        public string Passageiros { get; set; }
        public string Capacidade { get; set; }
        public string Placa { get; set; }
        public bool? Ativo { get; set; }
    }
}
