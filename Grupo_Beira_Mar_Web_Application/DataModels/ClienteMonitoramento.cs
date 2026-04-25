using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class ClienteMonitoramento
    {
        public int IdClienteMonitoramento { get; set; }
        public int IdCliente { get; set; }
        public int IdReceptoraMonitoramento { get; set; }
        public string Conta { get; set; }
        public bool? Ativo { get; set; }
        public bool? AutoTeste { get; set; }
        public bool? Feriado { get; set; }

        //public virtual Cliente Cliente { get; set; }
    }
}
