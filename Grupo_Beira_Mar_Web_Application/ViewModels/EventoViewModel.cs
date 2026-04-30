using Grupo_Beira_Mar_Web_Application.DataModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Grupo_Beira_Mar_Web_Application.ViewModels
{
    // ViewModel para consolidar dados de Evento, EventoMonitoramento, SMEAC e DetalhesSMEAC para a tela de edição
    public class EventoViewModel
    {
        // =========================================================
        // Campos da Tabela Evento (Seção ALARME)
        // =========================================================
        public int IdEvento { get; set; }

        [Display(Name = "Número Evento (Alarme)")]
        public int? EvtRest { get; set; } // Mapeado para Número Evento da seção Alarme

        [Display(Name = "Conta")]
        public string Conta { get; set; }

        [Display(Name = "Tipo Evento")]
        public string TipoEventoDescricao { get; set; } // Descrição amigável do tipo de evento

        [Display(Name = "Evento (Alarme)")]
        public string Evento1 { get; set; } // Mapeado para Evento da seção Alarme

        [Display(Name = "Grupo")]
        public string Grupo { get; set; }

        [Display(Name = "Zona")]
        public string Zona { get; set; }

        public int? IdFormato { get; set; } // FK para Formato

        [Display(Name = "Sinal Celular")]
        public string SinalCelular { get; set; }

        [Display(Name = "Tipo Rede")]
        public string TipoRede { get; set; }

        [Display(Name = "Data Evento")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? DataHoraEvento { get; set; } // Mapeado para Data Evento da seção Alarme

        public int? IdReceptora { get; set; } // FK para ReceptoraMonitoramento

        [Display(Name = "Qtd. Eventos")]
        public int? QtdEventos { get; set; }

        // =========================================================
        // Campos da Tabela EventoMonitoramento (Seção ATENDIMENTO)
        // =========================================================
        public int? IdEventoMonitoramento { get; set; }

        [Display(Name = "Número Monitoramento")]
        public int? NumeroMonitoramento { get; set; } // Mapeado para Número Monitoramento

        [Display(Name = "ID do Evento Monitorado")]
        public int EventoMonitoradoIdEvento { get; set; } // FK para Evento

        [Display(Name = "Usuário Atendimento")]
        public int? IdUsuarioAtendimento { get; set; } // FK para Usuario

        [Display(Name = "Nome Usuário Atendimento")]
        public string NomeUsuarioAtendimento { get; set; } // Para exibir o nome na tela

        [Display(Name = "Atendimento")]
        public bool Atendimento { get; set; } // Mapeado para Atendimento (checkbox)

        [Display(Name = "Concluído (Atendimento)")]
        public bool ConcluidoAtendimento { get; set; } // Mapeado para Concluído (checkbox)

        [Display(Name = "Ativo")]
        public bool AtivoAtendimento { get; set; } // Mapeado para Ativo (checkbox)

        [Display(Name = "Data Hora Início")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? DataHoraInicioAtendimento { get; set; }

        [Display(Name = "Data Hora Término")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? DataHoraTerminoAtendimento { get; set; }

        [Display(Name = "Descrição Monitoramento")]
        public string DescricaoMonitoramento { get; set; }

        // =========================================================
        // Campos da Tabela SMEAC (Seção SOLICITAÇÃO DE ATENDIMENTO ALARME)
        // =========================================================
        public int? IdSMEAC { get; set; } // PK da SMEAC

        [Display(Name = "Número Solicitação (SMEAC)")]
        public int? NumeroSolicitacaoSMEAC { get; set; } // Mapeado para Número Solicitação

        [Display(Name = "Data Solicitação Início")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? DataSolInicioSMEAC { get; set; }

        [Display(Name = "Data Solicitação Término")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? DataSolTerminoSMEAC { get; set; }

        [Display(Name = "Concluído (Solicitação)")]
        public bool ConcluidoSolSMEAC { get; set; }


        // =========================================================
        // Campos da Tabela DetalhesSMEAC (Seção DETALHES SOLICITAÇÃO DE ATENDIMENTO ALARME)
        // Pode haver múltiplos detalhes para uma SMEAC, então usamos uma lista.
        // =========================================================
        public List<DetalhesSMEACViewModel> DetalhesSMEAC { get; set; } = new List<DetalhesSMEACViewModel>();


        // =========================================================
        // Listas para Dropdowns
        // =========================================================
        public List<SelectListItem> Usuarios { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Veiculos { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> TiposEvento { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> DescricaoAtend { get; set; } = new List<SelectListItem>();
        public bool EventoPendente { get; set; }

        public EventoViewModel()
        {
            // Inicializa as propriedades booleanas para evitar problemas com nullables em checkboxes
            Atendimento = false;
            ConcluidoAtendimento = false;
            AtivoAtendimento = false;
            ConcluidoSolSMEAC = false;
        }
    }

    // ViewModel para os detalhes de SMEAC (pode haver vários em uma solicitação)
    public class DetalhesSMEACViewModel
    {
        public int? IdDetalhesSMEAC { get; set; }
        public int IdSMEAC { get; set; } // FK para SMEAC

        [Display(Name = "Vigilante Campo")]
        public int? IdUsuarioCampo { get; set; } // FK para Usuario

        [Display(Name = "Nome Vigilante Campo")]
        public string NomeUsuarioCampo { get; set; }

        [Display(Name = "Veículo Atendimento")]
        public int? IdVeiculoAtendimento { get; set; } // FK para Veiculo

        [Display(Name = "Descrição Veículo")]
        public string DescricaoVeiculoAtendimento { get; set; } // Para exibir o modelo/placa do veículo

        [Display(Name = "Descrição Detalhe")]
        public string DescricaoDetalhe { get; set; }

        [Display(Name = "Data Chegada")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? DataDetalheChegada { get; set; }

        [Display(Name = "Data Saída")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? DataDetalheSaida { get; set; }

        // Campo KM não tem mapeamento direto, pode ser um campo de input livre
        [Display(Name = "KM")]
        public string KM { get; set; }

        public bool PodeRemover { get; set; }
    }
}
