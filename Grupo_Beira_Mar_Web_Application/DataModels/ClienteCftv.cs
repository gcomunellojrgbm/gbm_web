using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class ClienteCftv
    {
        public int IdClienteCftv { get; set; }
        public int IdCliente { get; set; }
        public int IdTipoDispositivo { get; set; }
        public string Conta { get; set; }
        public string ContaMonitoramento { get; set; }
        public string UrlConexao1 { get; set; }
        public string UrlConexao2 { get; set; }
        public string UrlConexao3 { get; set; }
        public string UrlConexao4 { get; set; }
        public string UrlConexao5 { get; set; }
        public string UrlConexao6 { get; set; }
        public string QuantidadeCamera { get; set; }
        public string CodigoEvt1 { get; set; }
        public string CodigoEvt2 { get; set; }
        public string CodigoEvt3 { get; set; }
        public string CodigoEvt4 { get; set; }
        public bool? Monitoramento { get; set; }
        public bool? Ativo { get; set; }
        public string UsuarioCftv { get; set; }
        public string SenhaCftv { get; set; }
    }
}
