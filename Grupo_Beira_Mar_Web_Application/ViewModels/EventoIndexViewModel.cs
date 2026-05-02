using Grupo_Beira_Mar_Web_Application.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Grupo_Beira_Mar_Web_Application.ViewModels
{
    // ViewModel específico para a tela de listagem de Eventos
    public class EventoIndexViewModel
    {
        public int IdEvento { get; set; }

        [Display(Name = "Número Evento")]
        public int? NumeroEvento { get; set; }

        public string Conta { get; set; }

        [Display(Name = "Nome Cliente")]
        public string NomeCliente { get; set; } // Campo para exibir o nome do cliente

        [Display(Name = "Data Evento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        public DateTime? DataEvento { get; set; }

        [Display(Name = "Tipo Evento")]
        public string TipoEvento { get; set; } // Mapeado para Evento1

        //public string Grupo { get; set; }

        //public string Zona { get; set; }
        public int QtdEvento { get; set; }
        public string Endereco { get; set; }
        public string NumeroChip { get; set; }
        public string ReceptoraNome { get; set; }
        public int IdCliente { get; set; }
        public bool GeraAtendimento { get; set; }
        public bool DisparaSom { get; set; }
        public string CorEvento { get; internal set; }
    }

    public class EventosPendentesViewModel
    {
        public List<EventoIndexViewModel> EventosPendentes { get; set; }
        public List<ResumoFKSViewModel> ResumoFKS { get; set; }
    }

    public class EventosFKSViewModel
    {
        public EventosFKSViewModel()
        {
            this.Eventos = new List<EventosFKSItemViewModel>();
        }

        public int IdEventoEstado { get; set; }
        public List<EventosFKSItemViewModel> Eventos { get; set; }
        public string Descricao { get; internal set; }
    }

    public class EventosFKSItemViewModel
    {
        public int IdEventoEstado { get; set; }
        public string Descricao { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public DateTime? DataHora { get; set; }
    }
}
