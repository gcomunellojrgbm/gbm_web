using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class SolicitacaoChave
    {
        public int IdSolicitacaoChave { get; set; }
        public int IdUsuario { get; set; }
        public string Conta { get; set; }
        public string Responsavel { get; set; }
        public string DocumentoSol { get; set; }
        public string Placa { get; set; }
        public string TelefoneResp { get; set; }
        public DateTime? DataEntrega { get; set; }
        public DateTime? DataDevolvida { get; set; }
        public DateTime? DataAgendada { get; set; }
        public bool? Entregue { get; set; }
        public bool? Ativo { get; set; }
    }
}
