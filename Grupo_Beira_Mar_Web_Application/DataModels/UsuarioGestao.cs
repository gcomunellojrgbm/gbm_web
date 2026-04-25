using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class UsuarioGestao
    {
        public int IdUsuarioGestao { get; set; }
        public int IdUsuario { get; set; }
        public int IdTipoServicoUsuario { get; set; }
        public string Atividades { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }
        public string TempoExpediente { get; set; }
    }
}
