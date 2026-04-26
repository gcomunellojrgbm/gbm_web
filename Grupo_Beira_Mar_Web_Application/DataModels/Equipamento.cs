using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class Equipamento
    {
        public int IdEquipamento { get; set; }
        public int IdCliente { get; set; }
        public string NomeEquipamento { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Tag { get; set; }
        public string NumeroSerie { get; set; }
        public string Descricao { get; set; }
        public bool Iscliente { get; set; }
        public string TempoVdUtil { get; set; }
        public string TempoUsado { get; set; }
        public DateTime? DataInstalado { get; set; }
        public string Prateleira { get; set; }
        public string Estante { get; set; }
        public string Local { get; set; }
        public bool AtivoEquipamento { get; set; }
    }
}
