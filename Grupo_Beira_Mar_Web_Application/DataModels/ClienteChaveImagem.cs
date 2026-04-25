using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class ClienteChaveImagem
    {
        public int IdClienteChaveImagem { get; set; }
        public string Conta { get; set; }
        public string Nome1 { get; set; }
        public string Documento1 { get; set; }
        public string Nome2 { get; set; }
        public string Documento2 { get; set; }
        public byte[] Imagem1 { get; set; }
        public byte[] Imagem2 { get; set; }
    }
}
