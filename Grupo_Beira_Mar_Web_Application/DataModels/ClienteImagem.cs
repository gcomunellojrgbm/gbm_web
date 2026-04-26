using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class ClienteImagem
    {
        public int IdClienteImagem { get; set; }
        public int IdCliente { get; set; }
        public byte[] Imagem1 { get; set; }
        public byte[] Imagem2 { get; set; }
        public byte[] Imagem3 { get; set; }
        public string ObsContato { get; set; }
    }
}
