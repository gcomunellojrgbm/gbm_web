using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Grupo_Beira_Mar_Web_Application.Data.Migrations
{
    public partial class InicialDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "aniversario",
                columns: table => new
                {
                    id_aniversario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    data = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ano = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    contato = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    ativo = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aniversario", x => x.id_aniversario);
                });

            migrationBuilder.CreateTable(
                name: "atualizabdfinanc",
                columns: table => new
                {
                    id_atualizabdfinanc = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    atualiza = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_atualizabdfinanc", x => x.id_atualizabdfinanc);
                });

            migrationBuilder.CreateTable(
                name: "atualizabdserver",
                columns: table => new
                {
                    id_atualizabdserver = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_receptora_monitoramento = table.Column<int>(nullable: false),
                    atualiza = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_atualizabdserver", x => x.id_atualizabdserver);
                });

            migrationBuilder.CreateTable(
                name: "base",
                columns: table => new
                {
                    id_base = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    posto = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    ativo = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_base", x => x.id_base);
                });

            migrationBuilder.CreateTable(
                name: "boleto",
                columns: table => new
                {
                    id_boleto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_carne_boleto = table.Column<int>(nullable: false),
                    codigo = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    valor = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    data_vencimento = table.Column<DateTime>(type: "datetime", nullable: false),
                    data_pagamento = table.Column<DateTime>(type: "datetime", nullable: true),
                    ativo_boleto = table.Column<bool>(nullable: true),
                    pendente = table.Column<bool>(nullable: true),
                    atrasado = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_boleto", x => x.id_boleto);
                });

            migrationBuilder.CreateTable(
                name: "boleto_atendimento",
                columns: table => new
                {
                    id_boleto_atendimento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_boleto = table.Column<int>(nullable: false),
                    id_usuario = table.Column<int>(nullable: false),
                    data_atendimento = table.Column<DateTime>(type: "datetime", nullable: false),
                    descricao_atend = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    concluido = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_boleto_atendimento", x => x.id_boleto_atendimento);
                });

            migrationBuilder.CreateTable(
                name: "carne_boleto",
                columns: table => new
                {
                    id_carne_boleto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cliente = table.Column<int>(nullable: false),
                    tag = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    tipo_servico = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    data_cadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    descricao_carne = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    ativo = table.Column<bool>(nullable: true),
                    quitado = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carne_boleto", x => x.id_carne_boleto);
                });

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    id_cliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    nome = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    estado = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    cidade = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    bairro = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    logadouro = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    complemento = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    cep = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    nome_contato = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    telefone_contato = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    email_contato = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    proximidade_contato = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    obs_contato = table.Column<string>(unicode: false, maxLength: 300, nullable: true),
                    ativo = table.Column<bool>(nullable: true),
                    inadimplente = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.id_cliente);
                });

            migrationBuilder.CreateTable(
                name: "cliente_armado_periodo",
                columns: table => new
                {
                    id_cliente_armado_periodo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    conta = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    dia_semana = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    hora_inicio = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    hora_temino = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    ativo_armado_periodo = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente_armado_periodo", x => x.id_cliente_armado_periodo);
                });

            migrationBuilder.CreateTable(
                name: "cliente_cftv",
                columns: table => new
                {
                    id_cliente_cftv = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cliente = table.Column<int>(nullable: false),
                    id_tipo_dispositivo = table.Column<int>(nullable: false),
                    conta = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    conta_monitoramento = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    url_conexao_1 = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    url_conexao_2 = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    url_conexao_3 = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    url_conexao_4 = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    url_conexao_5 = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    url_conexao_6 = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    quantidade_camera = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    codigo_evt_1 = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    codigo_evt_2 = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    codigo_evt_3 = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    codigo_evt_4 = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    monitoramento = table.Column<bool>(nullable: true),
                    ativo = table.Column<bool>(nullable: true),
                    usuario_cftv = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    senha_cftv = table.Column<string>(unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente_cftv", x => x.id_cliente_cftv);
                });

            migrationBuilder.CreateTable(
                name: "cliente_chave_imagem",
                columns: table => new
                {
                    id_cliente_chave_imagem = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    conta = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    nome1 = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    documento1 = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    nome2 = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    documento2 = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    imagem1 = table.Column<byte[]>(nullable: true),
                    imagem2 = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente_chave_imagem", x => x.id_cliente_chave_imagem);
                });

            migrationBuilder.CreateTable(
                name: "cliente_escolta",
                columns: table => new
                {
                    id_cliente_escolta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cliente = table.Column<int>(nullable: false),
                    conta = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ativo = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente_escolta", x => x.id_cliente_escolta);
                });

            migrationBuilder.CreateTable(
                name: "cliente_imagem",
                columns: table => new
                {
                    id_cliente_imagem = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cliente = table.Column<int>(nullable: false),
                    imagem1 = table.Column<byte[]>(nullable: true),
                    imagem2 = table.Column<byte[]>(nullable: true),
                    imagem3 = table.Column<byte[]>(nullable: true),
                    obs_contato = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente_imagem", x => x.id_cliente_imagem);
                });

            migrationBuilder.CreateTable(
                name: "cliente_manutencao",
                columns: table => new
                {
                    id_cliente_manutencao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cliente = table.Column<int>(nullable: false),
                    conta = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ativo = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente_manutencao", x => x.id_cliente_manutencao);
                });

            migrationBuilder.CreateTable(
                name: "cliente_monitoramento",
                columns: table => new
                {
                    id_cliente_monitoramento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cliente = table.Column<int>(nullable: false),
                    id_receptora_monitoramento = table.Column<int>(nullable: false),
                    conta = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    ativo = table.Column<bool>(nullable: true),
                    auto_teste = table.Column<bool>(nullable: true),
                    feriado = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente_monitoramento", x => x.id_cliente_monitoramento);
                });

            migrationBuilder.CreateTable(
                name: "cliente_ronda",
                columns: table => new
                {
                    id_cliente_ronda = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_ronda = table.Column<int>(nullable: false),
                    id_cliente = table.Column<int>(nullable: false),
                    conta = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ativo = table.Column<bool>(nullable: true),
                    posicao_ronda = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente_ronda", x => x.id_cliente_ronda);
                });

            migrationBuilder.CreateTable(
                name: "cliente_servico",
                columns: table => new
                {
                    id_cliente_servico = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cliente = table.Column<int>(nullable: false),
                    id_tipo_servico = table.Column<int>(nullable: false),
                    ativo = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente_servico", x => x.id_cliente_servico);
                });

            migrationBuilder.CreateTable(
                name: "cliente_sol_chave",
                columns: table => new
                {
                    id_cliente_sol_chave = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cliente = table.Column<int>(nullable: false),
                    conta = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    documento = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ativo = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente_sol_chave", x => x.id_cliente_sol_chave);
                });

            migrationBuilder.CreateTable(
                name: "custo_extra",
                columns: table => new
                {
                    id_custo_extra = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_usuario = table.Column<int>(nullable: false),
                    descricao_custo = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    valor = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    documento = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    data_cadstro = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_custo_extra", x => x.id_custo_extra);
                });

            migrationBuilder.CreateTable(
                name: "custo_usuario",
                columns: table => new
                {
                    id_custo_usuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_tipo_custo_usuario = table.Column<int>(nullable: false),
                    id_usuario = table.Column<int>(nullable: false),
                    descricao_custo = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    valor = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    documento = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    data_cadstro = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_custo_usuario", x => x.id_custo_usuario);
                });

            migrationBuilder.CreateTable(
                name: "custo_veiculo",
                columns: table => new
                {
                    id_custo_veiculo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_veiculo = table.Column<int>(nullable: false),
                    id_usuario = table.Column<int>(nullable: false),
                    descricao_custo = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    valor = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    documento = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    data_cadstro = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_custo_veiculo", x => x.id_custo_veiculo);
                });

            migrationBuilder.CreateTable(
                name: "descricao_atend",
                columns: table => new
                {
                    id_descricao_atend = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao_atend = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_descricao_atend", x => x.id_descricao_atend);
                });

            migrationBuilder.CreateTable(
                name: "detalhe_cliente",
                columns: table => new
                {
                    id_detalhe_cliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cliente = table.Column<int>(nullable: false),
                    autorizacao = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    senha_contra = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    senha = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    chaves = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    telefone_2 = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    telefone_3 = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    data_cadastro = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    id_tipo_cliente = table.Column<int>(nullable: true),
                    endereco2 = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    cidade2 = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    cpf = table.Column<string>(unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalhe_cliente", x => x.id_detalhe_cliente);
                });

            migrationBuilder.CreateTable(
                name: "detalhe_veiculo",
                columns: table => new
                {
                    id_detalhe_veiculo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_veiculo = table.Column<int>(nullable: false),
                    km_atual = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    nivel_combustivel = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    autonomia = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    data_cadastro = table.Column<DateTime>(type: "datetime", nullable: true),
                    data_atual = table.Column<DateTime>(type: "datetime", nullable: true),
                    ativo = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalhe_veiculo", x => x.id_detalhe_veiculo);
                });

            migrationBuilder.CreateTable(
                name: "detalhes_s_m_e_a_c",
                columns: table => new
                {
                    id_detalhes_s_m_e_a_c = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_s_m_e_a_c = table.Column<int>(nullable: false),
                    id_usuario = table.Column<int>(nullable: true),
                    id_veiculo = table.Column<int>(nullable: true),
                    descricao_detalhe = table.Column<string>(unicode: false, maxLength: 400, nullable: true),
                    data_detalhe_chegada = table.Column<DateTime>(type: "datetime", nullable: true),
                    data_detalhe_saida = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalhes_s_m_e_a_c", x => x.id_detalhes_s_m_e_a_c);
                });

            migrationBuilder.CreateTable(
                name: "diario_bordo",
                columns: table => new
                {
                    id_diario_bordo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_usuario = table.Column<int>(nullable: true),
                    descricao = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    data = table.Column<DateTime>(type: "datetime", nullable: true),
                    concluido = table.Column<bool>(nullable: true),
                    conta = table.Column<string>(unicode: false, maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diario_bordo", x => x.id_diario_bordo);
                });

            migrationBuilder.CreateTable(
                name: "equipamento",
                columns: table => new
                {
                    id_equipamento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cliente = table.Column<int>(nullable: false),
                    nome_equipamento = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    marca = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    modelo = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    tag = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    numero_serie = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    descricao = table.Column<string>(unicode: false, maxLength: 400, nullable: true),
                    iscliente = table.Column<bool>(nullable: false),
                    tempo_vd_util = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    tempo_usado = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    data_instalado = table.Column<DateTime>(type: "datetime", nullable: true),
                    prateleira = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    estante = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    local = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ativo_equipamento = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipamento", x => x.id_equipamento);
                });

            migrationBuilder.CreateTable(
                name: "escolta",
                columns: table => new
                {
                    id_escolta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_usuario_cad = table.Column<int>(nullable: false),
                    conta = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    local_inicio = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    local_termino = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    data_escolta = table.Column<DateTime>(type: "datetime", nullable: true),
                    valor_patrimonio = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    valor_cobrado = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    valor_pagamento = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    forma_pagamento = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    doc_pagamento = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    recibo_pagamento = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    data_pagamento = table.Column<DateTime>(type: "datetime", nullable: true),
                    concluido_escolta = table.Column<bool>(nullable: true),
                    pendente = table.Column<bool>(nullable: true),
                    ativo_escolta = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_escolta", x => x.id_escolta);
                });

            migrationBuilder.CreateTable(
                name: "escolta_detalhe",
                columns: table => new
                {
                    id_escolta_detalhe = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_escolta = table.Column<int>(nullable: false),
                    id_usuario_escolta = table.Column<int>(nullable: false),
                    id_veiculo = table.Column<int>(nullable: false),
                    data_inicio = table.Column<DateTime>(type: "datetime", nullable: true),
                    data_fim = table.Column<DateTime>(type: "datetime", nullable: true),
                    descricao_escolta = table.Column<string>(unicode: false, maxLength: 400, nullable: true),
                    concluido_detalhe = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_escolta_detalhe", x => x.id_escolta_detalhe);
                });

            migrationBuilder.CreateTable(
                name: "evento",
                columns: table => new
                {
                    id_evento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    conta = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    evtRest = table.Column<int>(nullable: true),
                    evento = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    grupo = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    zona = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    id_formato = table.Column<int>(nullable: true),
                    sinal_celular = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    tipo_rede = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    data_hora = table.Column<DateTime>(type: "datetime", nullable: true),
                    id_receptora = table.Column<int>(nullable: true),
                    qtd_eventos = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evento", x => x.id_evento);
                });

            migrationBuilder.CreateTable(
                name: "evento_arme",
                columns: table => new
                {
                    id_evento_arme = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_formato = table.Column<int>(nullable: true),
                    id_receptora = table.Column<int>(nullable: true),
                    conta = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    armado = table.Column<bool>(nullable: true),
                    data_hora = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evento_arme", x => x.id_evento_arme);
                });

            migrationBuilder.CreateTable(
                name: "evento_arme_periodo",
                columns: table => new
                {
                    id_evento_arme_periodo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_evento = table.Column<int>(nullable: true),
                    conta = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    data_hora = table.Column<DateTime>(type: "datetime", nullable: true),
                    isarmado = table.Column<bool>(nullable: true),
                    isvisivel = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evento_arme_periodo", x => x.id_evento_arme_periodo);
                });

            migrationBuilder.CreateTable(
                name: "evento_corte_rede",
                columns: table => new
                {
                    id_evento_corte_rede = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_formato = table.Column<int>(nullable: true),
                    id_receptora = table.Column<int>(nullable: true),
                    conta = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    corte_rede = table.Column<bool>(nullable: true),
                    data_hora = table.Column<DateTime>(type: "datetime", nullable: true),
                    visivel = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evento_corte_rede", x => x.id_evento_corte_rede);
                });

            migrationBuilder.CreateTable(
                name: "evento_last",
                columns: table => new
                {
                    id_evento_last = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_evento = table.Column<int>(nullable: true),
                    conta = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    evento = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    data_hora = table.Column<DateTime>(type: "datetime", nullable: true),
                    isfalha = table.Column<bool>(nullable: true),
                    visivel = table.Column<bool>(nullable: true),
                    evtRest = table.Column<int>(nullable: true),
                    id_formato = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evento_last", x => x.id_evento_last);
                });

            migrationBuilder.CreateTable(
                name: "evento_monitoramento",
                columns: table => new
                {
                    id_evento_monitoramento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_evento = table.Column<int>(nullable: false),
                    id_usuario = table.Column<int>(nullable: true),
                    atendimento = table.Column<bool>(nullable: true),
                    concluido = table.Column<bool>(nullable: true),
                    ativo = table.Column<bool>(nullable: true),
                    data_hora_inicio = table.Column<DateTime>(type: "datetime", nullable: true),
                    data_hora_termino = table.Column<DateTime>(type: "datetime", nullable: true),
                    descricao_monitoramento = table.Column<string>(unicode: false, maxLength: 400, nullable: true),
                    id_receptora = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evento_monitoramento", x => x.id_evento_monitoramento);
                });

            migrationBuilder.CreateTable(
                name: "evento_setor",
                columns: table => new
                {
                    id_evento_setor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_formato = table.Column<int>(nullable: true),
                    conta = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    evento = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    grupo = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    zona = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    descricao_setor = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    ativo_setor = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evento_setor", x => x.id_evento_setor);
                });

            migrationBuilder.CreateTable(
                name: "formato",
                columns: table => new
                {
                    id_formato = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_formato", x => x.id_formato);
                });

            migrationBuilder.CreateTable(
                name: "grupo",
                columns: table => new
                {
                    id_grupo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    descricao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupo", x => x.id_grupo);
                });

            migrationBuilder.CreateTable(
                name: "grupo_usuario",
                columns: table => new
                {
                    id_grupo_usuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_usuario = table.Column<int>(nullable: true),
                    id_grupo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupo_usuario", x => x.id_grupo_usuario);
                });

            migrationBuilder.CreateTable(
                name: "inspecao_veiculo",
                columns: table => new
                {
                    id_inspecao_veiculo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_veiculo = table.Column<int>(nullable: false),
                    id_usuario = table.Column<int>(nullable: false),
                    descricao = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    km = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    data_cadstro = table.Column<DateTime>(type: "datetime", nullable: true),
                    ativo = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inspecao_veiculo", x => x.id_inspecao_veiculo);
                });

            migrationBuilder.CreateTable(
                name: "manutencao",
                columns: table => new
                {
                    id_manutencao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_usuario_cad = table.Column<int>(nullable: false),
                    conta = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    id_tipo_manutencao = table.Column<int>(nullable: true),
                    data_manutencao = table.Column<DateTime>(type: "datetime", nullable: true),
                    descricao_manutencao = table.Column<string>(unicode: false, maxLength: 400, nullable: true),
                    valor_cobrado = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    valor_pagamento = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    forma_pagamento = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    doc_pagamento = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    recibo_pagamento = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    data_pagamento = table.Column<DateTime>(type: "datetime", nullable: true),
                    concluido_manutencao = table.Column<bool>(nullable: true),
                    pendente = table.Column<bool>(nullable: true),
                    ativo_manutencao = table.Column<bool>(nullable: true),
                    radio = table.Column<bool>(nullable: true),
                    discadora = table.Column<bool>(nullable: true),
                    gprs = table.Column<bool>(nullable: true),
                    central = table.Column<bool>(nullable: true),
                    bateria = table.Column<bool>(nullable: true),
                    magnetos = table.Column<bool>(nullable: true),
                    fios = table.Column<bool>(nullable: true),
                    sirene = table.Column<bool>(nullable: true),
                    sensores = table.Column<bool>(nullable: true),
                    controle = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manutencao", x => x.id_manutencao);
                });

            migrationBuilder.CreateTable(
                name: "manutencao_detalhe",
                columns: table => new
                {
                    id_manutencao_detalhe = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_manutencao = table.Column<int>(nullable: false),
                    id_usuario_manutencao = table.Column<int>(nullable: false),
                    id_veiculo = table.Column<int>(nullable: false),
                    data_inicio = table.Column<DateTime>(type: "datetime", nullable: true),
                    data_fim = table.Column<DateTime>(type: "datetime", nullable: true),
                    descricao_manutencao_detalhe = table.Column<string>(unicode: false, maxLength: 400, nullable: true),
                    concluido_detalhe = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manutencao_detalhe", x => x.id_manutencao_detalhe);
                });

            migrationBuilder.CreateTable(
                name: "monitoramento_feriado",
                columns: table => new
                {
                    id_monitoramento_feriado = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dia = table.Column<int>(nullable: false),
                    mes = table.Column<int>(nullable: false),
                    ano = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    ativo = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monitoramento_feriado", x => x.id_monitoramento_feriado);
                });

            migrationBuilder.CreateTable(
                name: "pagamento_cliente",
                columns: table => new
                {
                    id_pagamento_cliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cliente = table.Column<int>(nullable: false),
                    id_usuario = table.Column<int>(nullable: false),
                    id_tipo_servico = table.Column<int>(nullable: false),
                    valor_cobrado = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    valor_pagamento = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    forma_pagamento = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    doc_pagamento = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    recibo_pagamento = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    data_pagamento = table.Column<DateTime>(type: "datetime", nullable: true),
                    pendente = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pagamento_cliente", x => x.id_pagamento_cliente);
                });

            migrationBuilder.CreateTable(
                name: "receptora_monitoramento",
                columns: table => new
                {
                    id_receptora_monitoramento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao_receptora = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    ativo_receptora_monitoramento = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receptora_monitoramento", x => x.id_receptora_monitoramento);
                });

            migrationBuilder.CreateTable(
                name: "recibo",
                columns: table => new
                {
                    id_recibo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cliente = table.Column<int>(nullable: false),
                    valor_recibo = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    importancia = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    data = table.Column<DateTime>(type: "datetime", nullable: true),
                    descricao = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    nome_empresa = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ativo_recibo = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recibo", x => x.id_recibo);
                });

            migrationBuilder.CreateTable(
                name: "ronda",
                columns: table => new
                {
                    id_ronda = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo_ronda = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    estado = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    cidade = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    bairro = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ativo = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ronda", x => x.id_ronda);
                });

            migrationBuilder.CreateTable(
                name: "ronda_gestao",
                columns: table => new
                {
                    id_ronda_gestao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_ronda = table.Column<int>(nullable: false),
                    id_usuario = table.Column<int>(nullable: false),
                    id_veiculo = table.Column<int>(nullable: false),
                    data_gestao = table.Column<DateTime>(type: "datetime", nullable: true),
                    quantidade_trajetos = table.Column<int>(nullable: true),
                    concluido = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ronda_gestao", x => x.id_ronda_gestao);
                });

            migrationBuilder.CreateTable(
                name: "ronda_gestao_detalhe",
                columns: table => new
                {
                    id_ronda_gestao_detalhe = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_ronda_gestao = table.Column<int>(nullable: false),
                    data_inicial = table.Column<DateTime>(type: "datetime", nullable: true),
                    data_termino = table.Column<DateTime>(type: "datetime", nullable: true),
                    descricao_detalhe = table.Column<string>(unicode: false, maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ronda_gestao_detalhe", x => x.id_ronda_gestao_detalhe);
                });

            migrationBuilder.CreateTable(
                name: "ronda_rua",
                columns: table => new
                {
                    id_ronda_rua = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_ronda = table.Column<int>(nullable: false),
                    rua = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ativo = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ronda_rua", x => x.id_ronda_rua);
                });

            migrationBuilder.CreateTable(
                name: "s_m_e_a_c",
                columns: table => new
                {
                    id_s_m_e_a_c = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_evento_monitoramento = table.Column<int>(nullable: true),
                    data_sol_inicio = table.Column<DateTime>(type: "datetime", nullable: true),
                    data_sol_termino = table.Column<DateTime>(type: "datetime", nullable: true),
                    concluido_sol = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_s_m_e_a_c", x => x.id_s_m_e_a_c);
                });

            migrationBuilder.CreateTable(
                name: "sistemer_system",
                columns: table => new
                {
                    id_sistemer_system = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    aplicacao = table.Column<int>(nullable: true),
                    data_inicial = table.Column<string>(unicode: false, maxLength: 80, nullable: true),
                    data_final = table.Column<string>(unicode: false, maxLength: 80, nullable: true),
                    timer_lic = table.Column<string>(unicode: false, maxLength: 80, nullable: true),
                    licensa = table.Column<string>(unicode: false, maxLength: 80, nullable: true),
                    ativo = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sistemer_system", x => x.id_sistemer_system);
                });

            migrationBuilder.CreateTable(
                name: "solicitacao_chave",
                columns: table => new
                {
                    id_solicitacao_chave = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_usuario = table.Column<int>(nullable: false),
                    conta = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    responsavel = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    documento_sol = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    placa = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    telefone_resp = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    data_entrega = table.Column<DateTime>(type: "datetime", nullable: true),
                    data_devolvida = table.Column<DateTime>(type: "datetime", nullable: true),
                    data_agendada = table.Column<DateTime>(type: "datetime", nullable: true),
                    entregue = table.Column<bool>(nullable: true),
                    ativo = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_solicitacao_chave", x => x.id_solicitacao_chave);
                });

            migrationBuilder.CreateTable(
                name: "tipo_cliente",
                columns: table => new
                {
                    id_tipo_cliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipocliente = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_cliente", x => x.id_tipo_cliente);
                });

            migrationBuilder.CreateTable(
                name: "tipo_custo_usuario",
                columns: table => new
                {
                    id_tipo_custo_usuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao_tc = table.Column<string>(unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_custo_usuario", x => x.id_tipo_custo_usuario);
                });

            migrationBuilder.CreateTable(
                name: "tipo_evento",
                columns: table => new
                {
                    id_tipo_evento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    evtRest = table.Column<int>(nullable: true),
                    evento = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    grupo = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    zona = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    id_formato = table.Column<int>(nullable: true),
                    descricao = table.Column<string>(unicode: false, maxLength: 400, nullable: true),
                    descricao_zona = table.Column<string>(unicode: false, maxLength: 400, nullable: true),
                    atendimento_manual = table.Column<bool>(nullable: true),
                    tocar_som = table.Column<bool>(nullable: true),
                    ativo = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_evento", x => x.id_tipo_evento);
                });

            migrationBuilder.CreateTable(
                name: "tipo_manutencao",
                columns: table => new
                {
                    id_tipo_manutencao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_tipo_manutencao = table.Column<string>(unicode: false, maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_manutencao", x => x.id_tipo_manutencao);
                });

            migrationBuilder.CreateTable(
                name: "tipo_servico",
                columns: table => new
                {
                    id_tipo_servico = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    obs = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ativo = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_servico", x => x.id_tipo_servico);
                });

            migrationBuilder.CreateTable(
                name: "tipo_servico_usuario",
                columns: table => new
                {
                    id_tipo_servico_usuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_servico_usuario", x => x.id_tipo_servico_usuario);
                });

            migrationBuilder.CreateTable(
                name: "tipo_veiculo",
                columns: table => new
                {
                    id_tipo_veiculo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(unicode: false, maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_veiculo", x => x.id_tipo_veiculo);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id_usuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cod_usuario = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    nome = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    senha = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<bool>(nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    telefone = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "usuario_gestao",
                columns: table => new
                {
                    id_usuario_gestao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_usuario = table.Column<int>(nullable: false),
                    id_tipo_servico_usuario = table.Column<int>(nullable: false),
                    atividades = table.Column<string>(unicode: false, maxLength: 400, nullable: true),
                    data_inicio = table.Column<DateTime>(type: "datetime", nullable: true),
                    data_termino = table.Column<DateTime>(type: "datetime", nullable: true),
                    tempo_expediente = table.Column<string>(unicode: false, maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario_gestao", x => x.id_usuario_gestao);
                });

            migrationBuilder.CreateTable(
                name: "veiculo",
                columns: table => new
                {
                    id_veiculo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_tipo_veiculo = table.Column<int>(nullable: false),
                    marca = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    modelo = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ano = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    potencia = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    cor = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    portas = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    passageiros = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    capacidade = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    placa = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ativo = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veiculo", x => x.id_veiculo);
                });

            migrationBuilder.CreateTable(
                name: "veiculo_combustivel",
                columns: table => new
                {
                    id_veiculo_combustivel = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_veiculo = table.Column<int>(nullable: false),
                    km_veiculo = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    qtd_combustivel = table.Column<double>(nullable: true),
                    custo_combustivel = table.Column<double>(nullable: true),
                    data_combustivel = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veiculo_combustivel", x => x.id_veiculo_combustivel);
                });

            migrationBuilder.CreateTable(
                name: "veiculo_gestao",
                columns: table => new
                {
                    id_veiculo_gestao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_veiculo = table.Column<int>(nullable: false),
                    id_usuario = table.Column<int>(nullable: false),
                    km_inical = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    km_final = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    nivel_combustivel = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    descricao_atividade = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    data_saida = table.Column<DateTime>(type: "datetime", nullable: true),
                    data_chegada = table.Column<DateTime>(type: "datetime", nullable: true),
                    id_base_saida = table.Column<int>(nullable: true),
                    id_base_retorno = table.Column<int>(nullable: true),
                    monitoramento = table.Column<bool>(nullable: true),
                    id_evento_monit = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veiculo_gestao", x => x.id_veiculo_gestao);
                });

            migrationBuilder.CreateTable(
                name: "veiculo_posicao",
                columns: table => new
                {
                    id_veiculo_posicao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_veiculo = table.Column<int>(nullable: false),
                    status = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ativo = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veiculo_posicao", x => x.id_veiculo_posicao);
                });

            migrationBuilder.CreateTable(
                name: "veiculo_posicao_usuario",
                columns: table => new
                {
                    id_veiculo_posicao_usuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_veiculo_posicao = table.Column<int>(nullable: false),
                    id_veiculo = table.Column<int>(nullable: false),
                    id_usuario = table.Column<int>(nullable: true),
                    id_base = table.Column<int>(nullable: true),
                    id_tipo_servico = table.Column<int>(nullable: true),
                    ativo = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veiculo_posicao_usuario", x => x.id_veiculo_posicao_usuario);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aniversario");

            migrationBuilder.DropTable(
                name: "atualizabdfinanc");

            migrationBuilder.DropTable(
                name: "atualizabdserver");

            migrationBuilder.DropTable(
                name: "base");

            migrationBuilder.DropTable(
                name: "boleto");

            migrationBuilder.DropTable(
                name: "boleto_atendimento");

            migrationBuilder.DropTable(
                name: "carne_boleto");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "cliente_armado_periodo");

            migrationBuilder.DropTable(
                name: "cliente_cftv");

            migrationBuilder.DropTable(
                name: "cliente_chave_imagem");

            migrationBuilder.DropTable(
                name: "cliente_escolta");

            migrationBuilder.DropTable(
                name: "cliente_imagem");

            migrationBuilder.DropTable(
                name: "cliente_manutencao");

            migrationBuilder.DropTable(
                name: "cliente_monitoramento");

            migrationBuilder.DropTable(
                name: "cliente_ronda");

            migrationBuilder.DropTable(
                name: "cliente_servico");

            migrationBuilder.DropTable(
                name: "cliente_sol_chave");

            migrationBuilder.DropTable(
                name: "custo_extra");

            migrationBuilder.DropTable(
                name: "custo_usuario");

            migrationBuilder.DropTable(
                name: "custo_veiculo");

            migrationBuilder.DropTable(
                name: "descricao_atend");

            migrationBuilder.DropTable(
                name: "detalhe_cliente");

            migrationBuilder.DropTable(
                name: "detalhe_veiculo");

            migrationBuilder.DropTable(
                name: "detalhes_s_m_e_a_c");

            migrationBuilder.DropTable(
                name: "diario_bordo");

            migrationBuilder.DropTable(
                name: "equipamento");

            migrationBuilder.DropTable(
                name: "escolta");

            migrationBuilder.DropTable(
                name: "escolta_detalhe");

            migrationBuilder.DropTable(
                name: "evento");

            migrationBuilder.DropTable(
                name: "evento_arme");

            migrationBuilder.DropTable(
                name: "evento_arme_periodo");

            migrationBuilder.DropTable(
                name: "evento_corte_rede");

            migrationBuilder.DropTable(
                name: "evento_last");

            migrationBuilder.DropTable(
                name: "evento_monitoramento");

            migrationBuilder.DropTable(
                name: "evento_setor");

            migrationBuilder.DropTable(
                name: "formato");

            migrationBuilder.DropTable(
                name: "grupo");

            migrationBuilder.DropTable(
                name: "grupo_usuario");

            migrationBuilder.DropTable(
                name: "inspecao_veiculo");

            migrationBuilder.DropTable(
                name: "manutencao");

            migrationBuilder.DropTable(
                name: "manutencao_detalhe");

            migrationBuilder.DropTable(
                name: "monitoramento_feriado");

            migrationBuilder.DropTable(
                name: "pagamento_cliente");

            migrationBuilder.DropTable(
                name: "receptora_monitoramento");

            migrationBuilder.DropTable(
                name: "recibo");

            migrationBuilder.DropTable(
                name: "ronda");

            migrationBuilder.DropTable(
                name: "ronda_gestao");

            migrationBuilder.DropTable(
                name: "ronda_gestao_detalhe");

            migrationBuilder.DropTable(
                name: "ronda_rua");

            migrationBuilder.DropTable(
                name: "s_m_e_a_c");

            migrationBuilder.DropTable(
                name: "sistemer_system");

            migrationBuilder.DropTable(
                name: "solicitacao_chave");

            migrationBuilder.DropTable(
                name: "tipo_cliente");

            migrationBuilder.DropTable(
                name: "tipo_custo_usuario");

            migrationBuilder.DropTable(
                name: "tipo_evento");

            migrationBuilder.DropTable(
                name: "tipo_manutencao");

            migrationBuilder.DropTable(
                name: "tipo_servico");

            migrationBuilder.DropTable(
                name: "tipo_servico_usuario");

            migrationBuilder.DropTable(
                name: "tipo_veiculo");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "usuario_gestao");

            migrationBuilder.DropTable(
                name: "veiculo");

            migrationBuilder.DropTable(
                name: "veiculo_combustivel");

            migrationBuilder.DropTable(
                name: "veiculo_gestao");

            migrationBuilder.DropTable(
                name: "veiculo_posicao");

            migrationBuilder.DropTable(
                name: "veiculo_posicao_usuario");
        }
    }
}
