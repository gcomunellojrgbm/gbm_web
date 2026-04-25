using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class ClienteRonda
    {
        public int IdClienteRonda { get; set; }
        public int IdRonda { get; set; }
        public int IdCliente { get; set; }
        public string Conta { get; set; }
        public bool? Ativo { get; set; }
        public int? PosicaoRonda { get; set; }
    }
}
