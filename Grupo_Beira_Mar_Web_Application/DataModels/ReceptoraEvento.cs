using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Grupo_Beira_Mar_Web_Application.DataModels
{
    public partial class ReceptoraEvento
    {
        public int IdEvento { get; set; }
        
        public string Evento { get; set; }

        virtual public Receptora Receptora { get; set; }
        public int IdReceptora { get; internal set; }
    }
}
