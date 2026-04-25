using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string CodUsuario { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public bool? Status { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
