using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class Recibo
    {
        public int IdRecibo { get; set; }
        public int IdCliente { get; set; }
        public string ValorRecibo { get; set; }
        public string Importancia { get; set; }
        public DateTime? Data { get; set; }
        public string Descricao { get; set; }
        public string NomeEmpresa { get; set; }
        public bool? AtivoRecibo { get; set; }
    }
}
