using Grupo_Beira_Mar_Web_Application.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Grupo_Beira_Mar_Web_Application.ViewModels
{
    public class DashboardViewModel
    {
        // =========================================================
        // 1. Visão Geral (Cards de Indicadores Chave)
        // =========================================================
        public int TotalEventosRegistradosHoje { get; set; }
        public int TotalEventosRegistradosMes { get; set; }
        public int TotalEventosRegistradosAno { get; set; }

        public int EventosPendentesAtendimento { get; set; }
        public int EventosConcluidosHoje { get; set; }
        public int EventosConcluidosMes { get; set; }
        public int EventosConcluidosAno { get; set; }

        public TimeSpan TempoMedioAtendimento { get; set; } // Em minutos ou segundos, para facilitar a exibição

        public int TotalSolicitacoesAtendimentoSMEAC { get; set; }
        public int SolicitacoesAtendimentoPendentes { get; set; }

        // =========================================================
        // 2. Estatísticas de Eventos (Dados para Gráficos)
        // =========================================================
        public List<string> EventosPorPeriodoLabels { get; set; } = new List<string>(); // Meses ou dias
        public List<int> EventosPorPeriodoData { get; set; } = new List<int>(); // Contagem de eventos

        public List<string> EventosPorTipoLabels { get; set; } = new List<string>(); // Descrição do TipoEvento
        public List<int> EventosPorTipoData { get; set; } = new List<int>(); // Contagem de eventos por tipo

        public List<string> EventosPorStatusLabels { get; set; } = new List<string>(); // Status (Atendido, Concluído, etc.)
        public List<int> EventosPorStatusData { get; set; } = new List<int>(); // Contagem por status

        // =========================================================
        // 3. Desempenho do Atendimento
        // =========================================================
        public List<string> AtendimentosPorUsuarioLabels { get; set; } = new List<string>();// Nomes dos usuários
        public List<int> AtendimentosPorUsuarioData { get; set; } = new List<int>();// Contagem de atendimentos por usuário

        public List<string> TempoRespostaConclusaoLabels { get; set; } = new List<string>();// Meses ou dias
        public List<double> TempoRespostaData { get; set; } = new List<double>();// Tempo médio de resposta
        public List<double> TempoConclusaoData { get; set; } = new List<double>();// Tempo médio de conclusão

        // =========================================================
        // 4. Atividade de Campo
        // =========================================================
        public List<string> OcorrenciasPorVeiculoLabels { get; set; } = new List<string>();// Marca/Modelo/Placa do veículo
        public List<int> OcorrenciasPorVeiculoData { get; set; } = new List<int>();// Contagem de ocorrências por veículo

        public List<string> OcorrenciasPorVigilanteCampoLabels { get; set; } = new List<string>();// Nomes dos vigilantes de campo
        public List<int> OcorrenciasPorVigilanteCampoData { get; set; } = new List<int>(); // Contagem de ocorrências por vigilante

        public List<SMEACTableItem> UltimasSolicitacoesSMEAC { get; set; } = new List<SMEACTableItem>();

        // =========================================================
        // 5. Análise Geográfica (usando dados de Cliente.Estado/Cidade)
        // =========================================================
        public List<string> EventosPorLocalizacaoLabels { get; set; } = new List<string>();// Estados/Cidades
        public List<int> EventosPorLocalizacaoData { get; set; } = new List<int>();// Contagem de eventos por localização


        public DashboardViewModel()
        {
            // Inicialização padrão para evitar nulls na View
            TempoMedioAtendimento = TimeSpan.Zero;
        }
    }

    // Classe auxiliar para a tabela de Últimas Solicitações
    public class SMEACTableItem
    {
        public int NumeroSolicitacao { get; set; }
        public int? NumeroMonitoramento { get; set; }
        public DateTime? DataInicioSolicitacao { get; set; }
        public DateTime? DataTerminoSolicitacao { get; set; }
        public bool ConcluidoSolicitacao { get; set; }
        public string DescricaoDetalhe { get; set; } // Último detalhe
        public string VigilanteCampo { get; set; } // Último vigilante
        public string VeiculoAtendimento { get; set; } // Último veículo
    }
}
