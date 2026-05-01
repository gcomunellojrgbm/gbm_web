using Grupo_Beira_Mar_Web_Application.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grupo_Beira_Mar_Web_Application.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            var connectionString = options.Extensions
           .OfType<Microsoft.EntityFrameworkCore.Infrastructure.RelationalOptionsExtension>()
           .FirstOrDefault()?.ConnectionString;

        }

        public virtual DbSet<Aniversario> Aniversario { get; set; }
        public virtual DbSet<Atualizabdfinanc> Atualizabdfinanc { get; set; }
        public virtual DbSet<Atualizabdserver> Atualizabdserver { get; set; }
        public virtual DbSet<Base> Base { get; set; }
        public virtual DbSet<Boleto> Boleto { get; set; }
        public virtual DbSet<BoletoAtendimento> BoletoAtendimento { get; set; }
        public virtual DbSet<CarneBoleto> CarneBoleto { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<ClienteArmadoPeriodo> ClienteArmadoPeriodo { get; set; }
        public virtual DbSet<ClienteCftv> ClienteCftv { get; set; }
        public virtual DbSet<ClienteChaveImagem> ClienteChaveImagem { get; set; }
        public virtual DbSet<ClienteEscolta> ClienteEscolta { get; set; }
        public virtual DbSet<ClienteImagem> ClienteImagem { get; set; }
        public virtual DbSet<ClienteManutencao> ClienteManutencao { get; set; }
        public virtual DbSet<ClienteMonitoramento> ClienteMonitoramento { get; set; }
        public virtual DbSet<ClienteRonda> ClienteRonda { get; set; }
        public virtual DbSet<ClienteServico> ClienteServico { get; set; }
        public virtual DbSet<ClienteSolChave> ClienteSolChave { get; set; }
        public virtual DbSet<CustoExtra> CustoExtra { get; set; }
        public virtual DbSet<CustoUsuario> CustoUsuario { get; set; }
        public virtual DbSet<CustoVeiculo> CustoVeiculo { get; set; }
        public virtual DbSet<DescricaoAtend> DescricaoAtend { get; set; }
        public virtual DbSet<DetalheCliente> DetalheCliente { get; set; }
        public virtual DbSet<DetalheVeiculo> DetalheVeiculo { get; set; }
        public virtual DbSet<DetalhesSMEAC> DetalhesSMEAC { get; set; }
        public virtual DbSet<DiarioBordo> DiarioBordo { get; set; }
        public virtual DbSet<Equipamento> Equipamento { get; set; }
        public virtual DbSet<Escolta> Escolta { get; set; }
        public virtual DbSet<EscoltaDetalhe> EscoltaDetalhe { get; set; }
        public virtual DbSet<Evento> Evento { get; set; }
        public virtual DbSet<EventoArme> EventoArme { get; set; }
        public virtual DbSet<EventoArmePeriodo> EventoArmePeriodo { get; set; }
        public virtual DbSet<EventoCorteRede> EventoCorteRede { get; set; }
        public virtual DbSet<EventoLast> EventoLast { get; set; }
        public virtual DbSet<EventoMonitoramento> EventoMonitoramento { get; set; }
        public virtual DbSet<EventoSetor> EventoSetor { get; set; }
        public virtual DbSet<Formato> Formato { get; set; }
        public virtual DbSet<Grupo> Grupo { get; set; }
        public virtual DbSet<GrupoUsuario> GrupoUsuario { get; set; }
        public virtual DbSet<InspecaoVeiculo> InspecaoVeiculo { get; set; }
        public virtual DbSet<Manutencao> Manutencao { get; set; }
        public virtual DbSet<ManutencaoDetalhe> ManutencaoDetalhe { get; set; }
        public virtual DbSet<MonitoramentoFeriado> MonitoramentoFeriado { get; set; }
        public virtual DbSet<PagamentoCliente> PagamentoCliente { get; set; }
        public virtual DbSet<Receptora> Receptora { get; set; }
        public virtual DbSet<ReceptoraEvento> ReceptoraEvento { get; set; }
        public virtual DbSet<ReceptoraMonitoramento> ReceptoraMonitoramento { get; set; }
        public virtual DbSet<Recibo> Recibo { get; set; }
        public virtual DbSet<Ronda> Ronda { get; set; }
        public virtual DbSet<RondaGestao> RondaGestao { get; set; }
        public virtual DbSet<RondaGestaoDetalhe> RondaGestaoDetalhe { get; set; }
        public virtual DbSet<RondaRua> RondaRua { get; set; }
        public virtual DbSet<SMEAC> SMEAC { get; set; }
        public virtual DbSet<SistemerSystem> SistemerSystem { get; set; }
        public virtual DbSet<SolicitacaoChave> SolicitacaoChave { get; set; }
        public virtual DbSet<TipoCliente> TipoCliente { get; set; }
        public virtual DbSet<TipoCustoUsuario> TipoCustoUsuario { get; set; }
        public virtual DbSet<TipoEvento> TipoEvento { get; set; }
        public virtual DbSet<TipoManutencao> TipoManutencao { get; set; }
        public virtual DbSet<TipoServico> TipoServico { get; set; }
        public virtual DbSet<TipoServicoUsuario> TipoServicoUsuario { get; set; }
        public virtual DbSet<TipoVeiculo> TipoVeiculo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioGestao> UsuarioGestao { get; set; }
        public virtual DbSet<Veiculo> Veiculo { get; set; }
        public virtual DbSet<VeiculoCombustivel> VeiculoCombustivel { get; set; }
        public virtual DbSet<VeiculoGestao> VeiculoGestao { get; set; }
        public virtual DbSet<VeiculoPosicao> VeiculoPosicao { get; set; }
        public virtual DbSet<VeiculoPosicaoUsuario> VeiculoPosicaoUsuario { get; set; }

        public virtual DbSet<EventoEstado> EventoEstado { get; set; }
        public virtual DbSet<EventoEstadoAcao> EventoEstadoAcao { get; set; }
        public virtual DbSet<ReceptoraAcao> ReceptoraAcao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //###################################################
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
            {
                b.Property<string>("Id")
                    .HasColumnType("nvarchar(450)");

                b.Property<string>("ConcurrencyStamp")
                    .IsConcurrencyToken()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(256)")
                    .HasMaxLength(256);

                b.Property<string>("NormalizedName")
                    .HasColumnType("nvarchar(256)")
                    .HasMaxLength(256);

                b.HasKey("Id");

                b.HasIndex("NormalizedName")
                    .IsUnique()
                    .HasName("RoleNameIndex")
                    .HasFilter("[NormalizedName] IS NOT NULL");

                b.ToTable("AspNetRoles");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("ClaimType")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("ClaimValue")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("RoleId")
                    .IsRequired()
                    .HasColumnType("nvarchar(450)");

                b.HasKey("Id");

                b.HasIndex("RoleId");

                b.ToTable("AspNetRoleClaims");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
            {
                b.Property<string>("Id")
                    .HasColumnType("nvarchar(450)");

                b.Property<int>("AccessFailedCount")
                    .HasColumnType("int");

                b.Property<string>("ConcurrencyStamp")
                    .IsConcurrencyToken()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Email")
                    .HasColumnType("nvarchar(256)")
                    .HasMaxLength(256);

                b.Property<bool>("EmailConfirmed")
                    .HasColumnType("bit");

                b.Property<bool>("LockoutEnabled")
                    .HasColumnType("bit");

                b.Property<DateTimeOffset?>("LockoutEnd")
                    .HasColumnType("datetimeoffset");

                b.Property<string>("NormalizedEmail")
                    .HasColumnType("nvarchar(256)")
                    .HasMaxLength(256);

                b.Property<string>("NormalizedUserName")
                    .HasColumnType("nvarchar(256)")
                    .HasMaxLength(256);

                b.Property<string>("PasswordHash")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("PhoneNumber")
                    .HasColumnType("nvarchar(max)");

                b.Property<bool>("PhoneNumberConfirmed")
                    .HasColumnType("bit");

                b.Property<string>("SecurityStamp")
                    .HasColumnType("nvarchar(max)");

                b.Property<bool>("TwoFactorEnabled")
                    .HasColumnType("bit");

                b.Property<string>("UserName")
                    .HasColumnType("nvarchar(256)")
                    .HasMaxLength(256);

                b.HasKey("Id");

                b.HasIndex("NormalizedEmail")
                    .HasName("EmailIndex");

                b.HasIndex("NormalizedUserName")
                    .IsUnique()
                    .HasName("UserNameIndex")
                    .HasFilter("[NormalizedUserName] IS NOT NULL");

                b.ToTable("AspNetUsers");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("ClaimType")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("ClaimValue")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("UserId")
                    .IsRequired()
                    .HasColumnType("nvarchar(450)");

                b.HasKey("Id");

                b.HasIndex("UserId");

                b.ToTable("AspNetUserClaims");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
            {
                b.Property<string>("LoginProvider")
                    .HasColumnType("nvarchar(128)")
                    .HasMaxLength(128);

                b.Property<string>("ProviderKey")
                    .HasColumnType("nvarchar(128)")
                    .HasMaxLength(128);

                b.Property<string>("ProviderDisplayName")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("UserId")
                    .IsRequired()
                    .HasColumnType("nvarchar(450)");

                b.HasKey("LoginProvider", "ProviderKey");

                b.HasIndex("UserId");

                b.ToTable("AspNetUserLogins");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
            {
                b.Property<string>("UserId")
                    .HasColumnType("nvarchar(450)");

                b.Property<string>("RoleId")
                    .HasColumnType("nvarchar(450)");

                b.HasKey("UserId", "RoleId");

                b.HasIndex("RoleId");

                b.ToTable("AspNetUserRoles");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
            {
                b.Property<string>("UserId")
                    .HasColumnType("nvarchar(450)");

                b.Property<string>("LoginProvider")
                    .HasColumnType("nvarchar(128)")
                    .HasMaxLength(128);

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(128)")
                    .HasMaxLength(128);

                b.Property<string>("Value")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("UserId", "LoginProvider", "Name");

                b.ToTable("AspNetUserTokens");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
            {
                b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                    .WithMany()
                    .HasForeignKey("RoleId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
            {
                b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
            {
                b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
            {
                b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                    .WithMany()
                    .HasForeignKey("RoleId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
            {
                b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            //###################################################


            modelBuilder.Entity<Aniversario>(entity =>
            {
                entity.HasKey(e => e.IdAniversario);

                entity.ToTable("aniversario");

                entity.Property(e => e.IdAniversario).HasColumnName("id_aniversario");

                entity.Property(e => e.Ano)
                    .HasColumnName("ano")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.Contato)
                    .HasColumnName("contato")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Atualizabdfinanc>(entity =>
            {
                entity.HasKey(e => e.IdAtualizabdfinanc);

                entity.ToTable("atualizabdfinanc");

                entity.Property(e => e.IdAtualizabdfinanc).HasColumnName("id_atualizabdfinanc");

                entity.Property(e => e.Atualiza).HasColumnName("atualiza");
            });

            modelBuilder.Entity<Atualizabdserver>(entity =>
            {
                entity.HasKey(e => e.IdAtualizabdserver);

                entity.ToTable("atualizabdserver");

                entity.Property(e => e.IdAtualizabdserver).HasColumnName("id_atualizabdserver");

                entity.Property(e => e.Atualiza).HasColumnName("atualiza");

                entity.Property(e => e.IdReceptoraMonitoramento).HasColumnName("id_receptora_monitoramento");
            });

            modelBuilder.Entity<Base>(entity =>
            {
                entity.HasKey(e => e.IdBase);

                entity.ToTable("base");

                entity.Property(e => e.IdBase).HasColumnName("id_base");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Posto)
                    .HasColumnName("posto")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Boleto>(entity =>
            {
                entity.HasKey(e => e.IdBoleto);

                entity.ToTable("boleto");

                entity.Property(e => e.IdBoleto).HasColumnName("id_boleto");

                entity.Property(e => e.AtivoBoleto).HasColumnName("ativo_boleto");

                entity.Property(e => e.Atrasado).HasColumnName("atrasado");

                entity.Property(e => e.Codigo)
                    .HasColumnName("codigo")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DataPagamento)
                    .HasColumnName("data_pagamento")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataVencimento)
                    .HasColumnName("data_vencimento")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCarneBoleto).HasColumnName("id_carne_boleto");

                entity.Property(e => e.Pendente).HasColumnName("pendente");

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BoletoAtendimento>(entity =>
            {
                entity.HasKey(e => e.IdBoletoAtendimento);

                entity.ToTable("boleto_atendimento");

                entity.Property(e => e.IdBoletoAtendimento).HasColumnName("id_boleto_atendimento");

                entity.Property(e => e.Concluido).HasColumnName("concluido");

                entity.Property(e => e.DataAtendimento)
                    .HasColumnName("data_atendimento")
                    .HasColumnType("datetime");

                entity.Property(e => e.DescricaoAtend)
                    .IsRequired()
                    .HasColumnName("descricao_atend")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdBoleto).HasColumnName("id_boleto");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            });

            modelBuilder.Entity<CarneBoleto>(entity =>
            {
                entity.HasKey(e => e.IdCarneBoleto);

                entity.ToTable("carne_boleto");

                entity.Property(e => e.IdCarneBoleto).HasColumnName("id_carne_boleto");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.DataCadastro)
                    .HasColumnName("data_cadastro")
                    .HasColumnType("datetime");

                entity.Property(e => e.DescricaoCarne)
                    .HasColumnName("descricao_carne")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.Quitado).HasColumnName("quitado");

                entity.Property(e => e.Tag)
                    .HasColumnName("tag")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoServico)
                    .IsRequired()
                    .HasColumnName("tipo_servico")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.ToTable("cliente");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasColumnName("bairro")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasColumnName("cep")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("cidade")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasColumnName("codigo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .IsRequired()
                    .HasColumnName("complemento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailContato)
                    .HasColumnName("email_contato")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Inadimplente).HasColumnName("inadimplente");

                entity.Property(e => e.Logadouro)
                    .IsRequired()
                    .HasColumnName("logadouro")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NomeContato)
                    .HasColumnName("nome_contato")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ObsContato)
                    .HasColumnName("obs_contato")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ProximidadeContato)
                    .HasColumnName("proximidade_contato")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TelefoneContato)
                    .HasColumnName("telefone_contato")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdReceptora)
                    .HasColumnName("id_receptora");
            });
            
            
            modelBuilder.Entity<Cliente>()
                .HasOne(em => em.Receptora)
                .WithMany()
                .HasForeignKey(em => em.IdReceptora);

            modelBuilder.Entity<ClienteArmadoPeriodo>(entity =>
            {
                entity.HasKey(e => e.IdClienteArmadoPeriodo);

                entity.ToTable("cliente_armado_periodo");

                entity.Property(e => e.IdClienteArmadoPeriodo).HasColumnName("id_cliente_armado_periodo");

                entity.Property(e => e.AtivoArmadoPeriodo).HasColumnName("ativo_armado_periodo");

                entity.Property(e => e.Conta)
                    .IsRequired()
                    .HasColumnName("conta")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DiaSemana)
                    .IsRequired()
                    .HasColumnName("dia_semana")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HoraInicio)
                    .IsRequired()
                    .HasColumnName("hora_inicio")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HoraTemino)
                    .IsRequired()
                    .HasColumnName("hora_temino")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClienteCftv>(entity =>
            {
                entity.HasKey(e => e.IdClienteCftv);

                entity.ToTable("cliente_cftv");

                entity.Property(e => e.IdClienteCftv).HasColumnName("id_cliente_cftv");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.CodigoEvt1)
                    .HasColumnName("codigo_evt_1")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoEvt2)
                    .HasColumnName("codigo_evt_2")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoEvt3)
                    .HasColumnName("codigo_evt_3")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoEvt4)
                    .HasColumnName("codigo_evt_4")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Conta)
                    .IsRequired()
                    .HasColumnName("conta")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContaMonitoramento)
                    .HasColumnName("conta_monitoramento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdTipoDispositivo).HasColumnName("id_tipo_dispositivo");

                entity.Property(e => e.Monitoramento).HasColumnName("monitoramento");

                entity.Property(e => e.QuantidadeCamera)
                    .HasColumnName("quantidade_camera")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SenhaCftv)
                    .HasColumnName("senha_cftv")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UrlConexao1)
                    .IsRequired()
                    .HasColumnName("url_conexao_1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UrlConexao2)
                    .HasColumnName("url_conexao_2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UrlConexao3)
                    .HasColumnName("url_conexao_3")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UrlConexao4)
                    .HasColumnName("url_conexao_4")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UrlConexao5)
                    .HasColumnName("url_conexao_5")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UrlConexao6)
                    .HasColumnName("url_conexao_6")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioCftv)
                    .HasColumnName("usuario_cftv")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClienteChaveImagem>(entity =>
            {
                entity.HasKey(e => e.IdClienteChaveImagem);

                entity.ToTable("cliente_chave_imagem");

                entity.Property(e => e.IdClienteChaveImagem).HasColumnName("id_cliente_chave_imagem");

                entity.Property(e => e.Conta)
                    .IsRequired()
                    .HasColumnName("conta")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Documento1)
                    .HasColumnName("documento1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Documento2)
                    .HasColumnName("documento2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Imagem1).HasColumnName("imagem1");

                entity.Property(e => e.Imagem2).HasColumnName("imagem2");

                entity.Property(e => e.Nome1)
                    .HasColumnName("nome1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome2)
                    .HasColumnName("nome2")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClienteEscolta>(entity =>
            {
                entity.HasKey(e => e.IdClienteEscolta);

                entity.ToTable("cliente_escolta");

                entity.Property(e => e.IdClienteEscolta).HasColumnName("id_cliente_escolta");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.Conta)
                    .HasColumnName("conta")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            });

            modelBuilder.Entity<ClienteImagem>(entity =>
            {
                entity.HasKey(e => e.IdClienteImagem);

                entity.ToTable("cliente_imagem");

                entity.Property(e => e.IdClienteImagem).HasColumnName("id_cliente_imagem");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.Imagem1).HasColumnName("imagem1");

                entity.Property(e => e.Imagem2).HasColumnName("imagem2");

                entity.Property(e => e.Imagem3).HasColumnName("imagem3");

                entity.Property(e => e.ObsContato)
                    .HasColumnName("obs_contato")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<ClienteManutencao>(entity =>
            {
                entity.HasKey(e => e.IdClienteManutencao);

                entity.ToTable("cliente_manutencao");

                entity.Property(e => e.IdClienteManutencao).HasColumnName("id_cliente_manutencao");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.Conta)
                    .HasColumnName("conta")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            });

            modelBuilder.Entity<ClienteMonitoramento>(entity =>
            {
                entity.HasKey(e => e.IdClienteMonitoramento);

                entity.ToTable("cliente_monitoramento");

                entity.Property(e => e.IdClienteMonitoramento).HasColumnName("id_cliente_monitoramento");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.AutoTeste).HasColumnName("auto_teste");

                entity.Property(e => e.Conta)
                    .IsRequired()
                    .HasColumnName("conta")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Feriado).HasColumnName("feriado");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdReceptoraMonitoramento).HasColumnName("id_receptora_monitoramento");
            });

            modelBuilder.Entity<ClienteRonda>(entity =>
            {
                entity.HasKey(e => e.IdClienteRonda);

                entity.ToTable("cliente_ronda");

                entity.Property(e => e.IdClienteRonda).HasColumnName("id_cliente_ronda");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.Conta)
                    .HasColumnName("conta")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdRonda).HasColumnName("id_ronda");

                entity.Property(e => e.PosicaoRonda).HasColumnName("posicao_ronda");
            });

            modelBuilder.Entity<ClienteServico>(entity =>
            {
                entity.HasKey(e => e.IdClienteServico);

                entity.ToTable("cliente_servico");

                entity.Property(e => e.IdClienteServico).HasColumnName("id_cliente_servico");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdTipoServico).HasColumnName("id_tipo_servico");
            });

            modelBuilder.Entity<ClienteSolChave>(entity =>
            {
                entity.HasKey(e => e.IdClienteSolChave);

                entity.ToTable("cliente_sol_chave");

                entity.Property(e => e.IdClienteSolChave).HasColumnName("id_cliente_sol_chave");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.Conta)
                    .HasColumnName("conta")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Documento)
                    .HasColumnName("documento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            });

            modelBuilder.Entity<CustoExtra>(entity =>
            {
                entity.HasKey(e => e.IdCustoExtra);

                entity.ToTable("custo_extra");

                entity.Property(e => e.IdCustoExtra).HasColumnName("id_custo_extra");

                entity.Property(e => e.DataCadstro)
                    .HasColumnName("data_cadstro")
                    .HasColumnType("datetime");

                entity.Property(e => e.DescricaoCusto)
                    .HasColumnName("descricao_custo")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Documento)
                    .HasColumnName("documento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdCustoUsuario);

                entity.ToTable("custo_usuario");

                entity.Property(e => e.IdCustoUsuario).HasColumnName("id_custo_usuario");

                entity.Property(e => e.DataCadstro)
                    .HasColumnName("data_cadstro")
                    .HasColumnType("datetime");

                entity.Property(e => e.DescricaoCusto)
                    .HasColumnName("descricao_custo")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Documento)
                    .HasColumnName("documento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipoCustoUsuario).HasColumnName("id_tipo_custo_usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustoVeiculo>(entity =>
            {
                entity.HasKey(e => e.IdCustoVeiculo);

                entity.ToTable("custo_veiculo");

                entity.Property(e => e.IdCustoVeiculo).HasColumnName("id_custo_veiculo");

                entity.Property(e => e.DataCadstro)
                    .HasColumnName("data_cadstro")
                    .HasColumnType("datetime");

                entity.Property(e => e.DescricaoCusto)
                    .HasColumnName("descricao_custo")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Documento)
                    .HasColumnName("documento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.IdVeiculo).HasColumnName("id_veiculo");

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DescricaoAtend>(entity =>
            {
                entity.HasKey(e => e.IdDescricaoAtend);

                entity.ToTable("descricao_atend");

                entity.Property(e => e.IdDescricaoAtend).HasColumnName("id_descricao_atend");

                entity.Property(e => e.DescricaoAtend1)
                    .HasColumnName("descricao_atend")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetalheCliente>(entity =>
            {
                entity.HasKey(e => e.IdDetalheCliente);

                entity.ToTable("detalhe_cliente");

                entity.Property(e => e.IdDetalheCliente).HasColumnName("id_detalhe_cliente");

                entity.Property(e => e.Autorizacao)
                    .HasColumnName("autorizacao")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Chaves)
                    .HasColumnName("chaves")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade2)
                    .HasColumnName("cidade2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .HasColumnName("cpf")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DataCadastro)
                    .HasColumnName("data_cadastro")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco2)
                    .HasColumnName("endereco2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdTipoCliente).HasColumnName("id_tipo_cliente");

                entity.Property(e => e.Senha)
                    .HasColumnName("senha")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SenhaContra)
                    .HasColumnName("senha_contra")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone2)
                    .HasColumnName("telefone_2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone3)
                    .HasColumnName("telefone_3")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetalheVeiculo>(entity =>
            {
                entity.HasKey(e => e.IdDetalheVeiculo);

                entity.ToTable("detalhe_veiculo");

                entity.Property(e => e.IdDetalheVeiculo).HasColumnName("id_detalhe_veiculo");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.Autonomia)
                    .HasColumnName("autonomia")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DataAtual)
                    .HasColumnName("data_atual")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataCadastro)
                    .HasColumnName("data_cadastro")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdVeiculo).HasColumnName("id_veiculo");

                entity.Property(e => e.KmAtual)
                    .HasColumnName("km_atual")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NivelCombustivel)
                    .HasColumnName("nivel_combustivel")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetalhesSMEAC>(entity =>
            {
                entity.HasKey(e => e.IdDetalhesSMEAC);

                entity.ToTable("detalhes_s_m_e_a_c");

                entity.Property(e => e.IdDetalhesSMEAC).HasColumnName("id_detalhes_s_m_e_a_c");

                entity.Property(e => e.DataDetalheChegada)
                    .HasColumnName("data_detalhe_chegada")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataDetalheSaida)
                    .HasColumnName("data_detalhe_saida")
                    .HasColumnType("datetime");

                entity.Property(e => e.DescricaoDetalhe)
                    .HasColumnName("descricao_detalhe")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.IdSMEAC).HasColumnName("id_s_m_e_a_c");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.IdVeiculo).HasColumnName("id_veiculo");
            });

            modelBuilder.Entity<DiarioBordo>(entity =>
            {
                entity.HasKey(e => e.IdDiarioBordo);

                entity.ToTable("diario_bordo");

                entity.Property(e => e.IdDiarioBordo).HasColumnName("id_diario_bordo");

                entity.Property(e => e.Concluido).HasColumnName("concluido");

                entity.Property(e => e.Conta)
                    .HasColumnName("conta")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            });

            modelBuilder.Entity<Equipamento>(entity =>
            {
                entity.HasKey(e => e.IdEquipamento);

                entity.ToTable("equipamento");

                entity.Property(e => e.IdEquipamento).HasColumnName("id_equipamento");

                entity.Property(e => e.AtivoEquipamento).HasColumnName("ativo_equipamento");

                entity.Property(e => e.DataInstalado)
                    .HasColumnName("data_instalado")
                    .HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.Estante)
                    .HasColumnName("estante")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.Iscliente).HasColumnName("iscliente");

                entity.Property(e => e.Local)
                    .HasColumnName("local")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Marca)
                    .HasColumnName("marca")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .HasColumnName("modelo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NomeEquipamento)
                    .HasColumnName("nome_equipamento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroSerie)
                    .HasColumnName("numero_serie")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prateleira)
                    .HasColumnName("prateleira")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tag)
                    .HasColumnName("tag")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TempoUsado)
                    .HasColumnName("tempo_usado")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TempoVdUtil)
                    .HasColumnName("tempo_vd_util")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Escolta>(entity =>
            {
                entity.HasKey(e => e.IdEscolta);

                entity.ToTable("escolta");

                entity.Property(e => e.IdEscolta).HasColumnName("id_escolta");

                entity.Property(e => e.AtivoEscolta).HasColumnName("ativo_escolta");

                entity.Property(e => e.ConcluidoEscolta).HasColumnName("concluido_escolta");

                entity.Property(e => e.Conta)
                    .HasColumnName("conta")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DataEscolta)
                    .HasColumnName("data_escolta")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataPagamento)
                    .HasColumnName("data_pagamento")
                    .HasColumnType("datetime");

                entity.Property(e => e.DocPagamento)
                    .HasColumnName("doc_pagamento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FormaPagamento)
                    .HasColumnName("forma_pagamento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuarioCad).HasColumnName("id_usuario_cad");

                entity.Property(e => e.LocalInicio)
                    .HasColumnName("local_inicio")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LocalTermino)
                    .HasColumnName("local_termino")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Pendente).HasColumnName("pendente");

                entity.Property(e => e.ReciboPagamento)
                    .HasColumnName("recibo_pagamento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValorCobrado)
                    .HasColumnName("valor_cobrado")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValorPagamento)
                    .HasColumnName("valor_pagamento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValorPatrimonio)
                    .HasColumnName("valor_patrimonio")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EscoltaDetalhe>(entity =>
            {
                entity.HasKey(e => e.IdEscoltaDetalhe);

                entity.ToTable("escolta_detalhe");

                entity.Property(e => e.IdEscoltaDetalhe).HasColumnName("id_escolta_detalhe");

                entity.Property(e => e.ConcluidoDetalhe).HasColumnName("concluido_detalhe");

                entity.Property(e => e.DataFim)
                    .HasColumnName("data_fim")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataInicio)
                    .HasColumnName("data_inicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.DescricaoEscolta)
                    .HasColumnName("descricao_escolta")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.IdEscolta).HasColumnName("id_escolta");

                entity.Property(e => e.IdUsuarioEscolta).HasColumnName("id_usuario_escolta");

                entity.Property(e => e.IdVeiculo).HasColumnName("id_veiculo");
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.HasKey(e => e.IdEvento);

                entity.ToTable("evento");

                entity.Property(e => e.IdEvento).HasColumnName("id_evento");

                entity.Property(e => e.Conta)
                    .HasColumnName("conta")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DataHora)
                    .HasColumnName("data_hora")
                    .HasColumnType("datetime");

                entity.Property(e => e.Evento1)
                    .HasColumnName("evento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EvtRest).HasColumnName("evtRest");

                entity.Property(e => e.Grupo)
                    .HasColumnName("grupo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdFormato).HasColumnName("id_formato");

                entity.Property(e => e.IdReceptora).HasColumnName("id_receptora");

                entity.Property(e => e.QtdEventos).HasColumnName("qtd_eventos");

                entity.Property(e => e.SinalCelular)
                    .HasColumnName("sinal_celular")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoRede)
                    .HasColumnName("tipo_rede")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Zona)
                    .HasColumnName("zona")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EventoArme>(entity =>
            {
                entity.HasKey(e => e.IdEventoArme);

                entity.ToTable("evento_arme");

                entity.Property(e => e.IdEventoArme).HasColumnName("id_evento_arme");

                entity.Property(e => e.Armado).HasColumnName("armado");

                entity.Property(e => e.Conta)
                    .HasColumnName("conta")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DataHora)
                    .HasColumnName("data_hora")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdFormato).HasColumnName("id_formato");

                entity.Property(e => e.IdReceptora).HasColumnName("id_receptora");
            });

            modelBuilder.Entity<EventoArmePeriodo>(entity =>
            {
                entity.HasKey(e => e.IdEventoArmePeriodo);

                entity.ToTable("evento_arme_periodo");

                entity.Property(e => e.IdEventoArmePeriodo).HasColumnName("id_evento_arme_periodo");

                entity.Property(e => e.Conta)
                    .HasColumnName("conta")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DataHora)
                    .HasColumnName("data_hora")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdEvento).HasColumnName("id_evento");

                entity.Property(e => e.Isarmado).HasColumnName("isarmado");

                entity.Property(e => e.Isvisivel).HasColumnName("isvisivel");
            });

            modelBuilder.Entity<EventoCorteRede>(entity =>
            {
                entity.HasKey(e => e.IdEventoCorteRede);

                entity.ToTable("evento_corte_rede");

                entity.Property(e => e.IdEventoCorteRede).HasColumnName("id_evento_corte_rede");

                entity.Property(e => e.Conta)
                    .HasColumnName("conta")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CorteRede).HasColumnName("corte_rede");

                entity.Property(e => e.DataHora)
                    .HasColumnName("data_hora")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdFormato).HasColumnName("id_formato");

                entity.Property(e => e.IdReceptora).HasColumnName("id_receptora");

                entity.Property(e => e.Visivel).HasColumnName("visivel");
            });

            modelBuilder.Entity<EventoLast>(entity =>
            {
                entity.HasKey(e => e.IdEventoLast);

                entity.ToTable("evento_last");

                entity.Property(e => e.IdEventoLast).HasColumnName("id_evento_last");

                entity.Property(e => e.Conta)
                    .HasColumnName("conta")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DataHora)
                    .HasColumnName("data_hora")
                    .HasColumnType("datetime");

                entity.Property(e => e.Evento)
                    .HasColumnName("evento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EvtRest).HasColumnName("evtRest");

                entity.Property(e => e.IdEvento).HasColumnName("id_evento");

                entity.Property(e => e.IdFormato).HasColumnName("id_formato");

                entity.Property(e => e.Isfalha).HasColumnName("isfalha");

                entity.Property(e => e.Visivel).HasColumnName("visivel");
            });

            modelBuilder.Entity<EventoMonitoramento>(entity =>
            {
                entity.HasKey(e => e.IdEventoMonitoramento);

                entity.ToTable("evento_monitoramento");

                entity.Property(e => e.IdEventoMonitoramento).HasColumnName("id_evento_monitoramento");

                entity.Property(e => e.Atendimento).HasColumnName("atendimento");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.Concluido).HasColumnName("concluido");

                entity.Property(e => e.DataHoraInicio)
                    .HasColumnName("data_hora_inicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataHoraTermino)
                    .HasColumnName("data_hora_termino")
                    .HasColumnType("datetime");

                entity.Property(e => e.DescricaoMonitoramento)
                    .HasColumnName("descricao_monitoramento")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.IdEvento).HasColumnName("id_evento");

                entity.Property(e => e.IdReceptora).HasColumnName("id_receptora");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            });

            modelBuilder.Entity<EventoSetor>(entity =>
            {
                entity.HasKey(e => e.IdEventoSetor);

                entity.ToTable("evento_setor");

                entity.Property(e => e.IdEventoSetor).HasColumnName("id_evento_setor");

                entity.Property(e => e.AtivoSetor).HasColumnName("ativo_setor");

                entity.Property(e => e.Conta)
                    .HasColumnName("conta")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DescricaoSetor)
                    .HasColumnName("descricao_setor")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Evento)
                    .HasColumnName("evento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Grupo)
                    .HasColumnName("grupo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdFormato).HasColumnName("id_formato");

                entity.Property(e => e.Zona)
                    .HasColumnName("zona")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Formato>(entity =>
            {
                entity.HasKey(e => e.IdFormato);

                entity.ToTable("formato");

                entity.Property(e => e.IdFormato).HasColumnName("id_formato");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.HasKey(e => e.IdGrupo)
                    .HasName("PK_Grupo");

                entity.ToTable("grupo");

                entity.Property(e => e.IdGrupo).HasColumnName("id_grupo");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasColumnType("text");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GrupoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdGrupoUsuario);

                entity.ToTable("grupo_usuario");

                entity.Property(e => e.IdGrupoUsuario).HasColumnName("id_grupo_usuario");

                entity.Property(e => e.IdGrupo).HasColumnName("id_grupo");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            });

            modelBuilder.Entity<InspecaoVeiculo>(entity =>
            {
                entity.HasKey(e => e.IdInspecaoVeiculo);

                entity.ToTable("inspecao_veiculo");

                entity.Property(e => e.IdInspecaoVeiculo).HasColumnName("id_inspecao_veiculo");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.DataCadstro)
                    .HasColumnName("data_cadstro")
                    .HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.IdVeiculo).HasColumnName("id_veiculo");

                entity.Property(e => e.Km)
                    .HasColumnName("km")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Manutencao>(entity =>
            {
                entity.HasKey(e => e.IdManutencao);

                entity.ToTable("manutencao");

                entity.Property(e => e.IdManutencao).HasColumnName("id_manutencao");

                entity.Property(e => e.AtivoManutencao).HasColumnName("ativo_manutencao");

                entity.Property(e => e.Bateria).HasColumnName("bateria");

                entity.Property(e => e.Central).HasColumnName("central");

                entity.Property(e => e.ConcluidoManutencao).HasColumnName("concluido_manutencao");

                entity.Property(e => e.Conta)
                    .HasColumnName("conta")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Controle).HasColumnName("controle");

                entity.Property(e => e.DataManutencao)
                    .HasColumnName("data_manutencao")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataPagamento)
                    .HasColumnName("data_pagamento")
                    .HasColumnType("datetime");

                entity.Property(e => e.DescricaoManutencao)
                    .HasColumnName("descricao_manutencao")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.Discadora).HasColumnName("discadora");

                entity.Property(e => e.DocPagamento)
                    .HasColumnName("doc_pagamento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fios).HasColumnName("fios");

                entity.Property(e => e.FormaPagamento)
                    .HasColumnName("forma_pagamento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gprs).HasColumnName("gprs");

                entity.Property(e => e.IdTipoManutencao).HasColumnName("id_tipo_manutencao");

                entity.Property(e => e.IdUsuarioCad).HasColumnName("id_usuario_cad");

                entity.Property(e => e.Magnetos).HasColumnName("magnetos");

                entity.Property(e => e.Pendente).HasColumnName("pendente");

                entity.Property(e => e.Radio).HasColumnName("radio");

                entity.Property(e => e.ReciboPagamento)
                    .HasColumnName("recibo_pagamento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sensores).HasColumnName("sensores");

                entity.Property(e => e.Sirene).HasColumnName("sirene");

                entity.Property(e => e.ValorCobrado)
                    .HasColumnName("valor_cobrado")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValorPagamento)
                    .HasColumnName("valor_pagamento")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ManutencaoDetalhe>(entity =>
            {
                entity.HasKey(e => e.IdManutencaoDetalhe);

                entity.ToTable("manutencao_detalhe");

                entity.Property(e => e.IdManutencaoDetalhe).HasColumnName("id_manutencao_detalhe");

                entity.Property(e => e.ConcluidoDetalhe).HasColumnName("concluido_detalhe");

                entity.Property(e => e.DataFim)
                    .HasColumnName("data_fim")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataInicio)
                    .HasColumnName("data_inicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.DescricaoManutencaoDetalhe)
                    .HasColumnName("descricao_manutencao_detalhe")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.IdManutencao).HasColumnName("id_manutencao");

                entity.Property(e => e.IdUsuarioManutencao).HasColumnName("id_usuario_manutencao");

                entity.Property(e => e.IdVeiculo).HasColumnName("id_veiculo");
            });

            modelBuilder.Entity<MonitoramentoFeriado>(entity =>
            {
                entity.HasKey(e => e.IdMonitoramentoFeriado);

                entity.ToTable("monitoramento_feriado");

                entity.Property(e => e.IdMonitoramentoFeriado).HasColumnName("id_monitoramento_feriado");

                entity.Property(e => e.Ano)
                    .IsRequired()
                    .HasColumnName("ano")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.Dia).HasColumnName("dia");

                entity.Property(e => e.Mes).HasColumnName("mes");
            });

            modelBuilder.Entity<PagamentoCliente>(entity =>
            {
                entity.HasKey(e => e.IdPagamentoCliente);

                entity.ToTable("pagamento_cliente");

                entity.Property(e => e.IdPagamentoCliente).HasColumnName("id_pagamento_cliente");

                entity.Property(e => e.DataPagamento)
                    .HasColumnName("data_pagamento")
                    .HasColumnType("datetime");

                entity.Property(e => e.DocPagamento)
                    .HasColumnName("doc_pagamento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FormaPagamento)
                    .HasColumnName("forma_pagamento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdTipoServico).HasColumnName("id_tipo_servico");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Pendente).HasColumnName("pendente");

                entity.Property(e => e.ReciboPagamento)
                    .HasColumnName("recibo_pagamento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValorCobrado)
                    .HasColumnName("valor_cobrado")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValorPagamento)
                    .HasColumnName("valor_pagamento")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Receptora>(entity =>
            {
                entity.HasKey(e => e.IdReceptora);

                entity.ToTable("receptora");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(50);

            });

            modelBuilder.Entity<ReceptoraEvento>(entity =>
            {
                entity.HasKey(e => e.IdEvento);

                entity.ToTable("receptora_evento");

                entity.Property(e => e.IdReceptora).HasColumnName("id_receptora");

                entity.Property(e => e.Evento)
                    .HasColumnName("evento")
                    .HasMaxLength(200);

            });
            modelBuilder.Entity<ReceptoraEvento>()
                .HasOne(em => em.Receptora)
                .WithMany()
                .HasForeignKey(em => em.IdReceptora);


            modelBuilder.Entity<ReceptoraMonitoramento>(entity =>
            {
                entity.HasKey(e => e.IdReceptoraMonitoramento);

                entity.ToTable("receptora_monitoramento");

                entity.Property(e => e.IdReceptoraMonitoramento).HasColumnName("id_receptora_monitoramento");

                entity.Property(e => e.AtivoReceptoraMonitoramento).HasColumnName("ativo_receptora_monitoramento");

                entity.Property(e => e.DescricaoReceptora)
                    .HasColumnName("descricao_receptora")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Recibo>(entity =>
            {
                entity.HasKey(e => e.IdRecibo);

                entity.ToTable("recibo");

                entity.Property(e => e.IdRecibo).HasColumnName("id_recibo");

                entity.Property(e => e.AtivoRecibo).HasColumnName("ativo_recibo");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.Importancia)
                    .HasColumnName("importancia")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NomeEmpresa)
                    .HasColumnName("nome_empresa")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValorRecibo)
                    .HasColumnName("valor_recibo")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ronda>(entity =>
            {
                entity.HasKey(e => e.IdRonda);

                entity.ToTable("ronda");

                entity.Property(e => e.IdRonda).HasColumnName("id_ronda");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.Bairro)
                    .HasColumnName("bairro")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .HasColumnName("cidade")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoRonda)
                    .HasColumnName("codigo_ronda")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RondaGestao>(entity =>
            {
                entity.HasKey(e => e.IdRondaGestao);

                entity.ToTable("ronda_gestao");

                entity.Property(e => e.IdRondaGestao).HasColumnName("id_ronda_gestao");

                entity.Property(e => e.Concluido).HasColumnName("concluido");

                entity.Property(e => e.DataGestao)
                    .HasColumnName("data_gestao")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdRonda).HasColumnName("id_ronda");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.IdVeiculo).HasColumnName("id_veiculo");

                entity.Property(e => e.QuantidadeTrajetos).HasColumnName("quantidade_trajetos");
            });

            modelBuilder.Entity<RondaGestaoDetalhe>(entity =>
            {
                entity.HasKey(e => e.IdRondaGestaoDetalhe);

                entity.ToTable("ronda_gestao_detalhe");

                entity.Property(e => e.IdRondaGestaoDetalhe).HasColumnName("id_ronda_gestao_detalhe");

                entity.Property(e => e.DataInicial)
                    .HasColumnName("data_inicial")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataTermino)
                    .HasColumnName("data_termino")
                    .HasColumnType("datetime");

                entity.Property(e => e.DescricaoDetalhe)
                    .HasColumnName("descricao_detalhe")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.IdRondaGestao).HasColumnName("id_ronda_gestao");
            });

            modelBuilder.Entity<RondaRua>(entity =>
            {
                entity.HasKey(e => e.IdRondaRua);

                entity.ToTable("ronda_rua");

                entity.Property(e => e.IdRondaRua).HasColumnName("id_ronda_rua");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.IdRonda).HasColumnName("id_ronda");

                entity.Property(e => e.Rua)
                    .HasColumnName("rua")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SMEAC>(entity =>
            {
                entity.HasKey(e => e.IdSMEAC);

                entity.ToTable("s_m_e_a_c");

                entity.Property(e => e.IdSMEAC).HasColumnName("id_s_m_e_a_c");

                entity.Property(e => e.ConcluidoSol).HasColumnName("concluido_sol");

                entity.Property(e => e.DataSolInicio)
                    .HasColumnName("data_sol_inicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataSolTermino)
                    .HasColumnName("data_sol_termino")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdEventoMonitoramento).HasColumnName("id_evento_monitoramento");
            });

            modelBuilder.Entity<SistemerSystem>(entity =>
            {
                entity.HasKey(e => e.IdSistemerSystem);

                entity.ToTable("sistemer_system");

                entity.Property(e => e.IdSistemerSystem).HasColumnName("id_sistemer_system");

                entity.Property(e => e.Aplicacao).HasColumnName("aplicacao");

                entity.Property(e => e.Ativo)
                    .HasColumnName("ativo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DataFinal)
                    .HasColumnName("data_final")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.DataInicial)
                    .HasColumnName("data_inicial")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Licensa)
                    .HasColumnName("licensa")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.TimerLic)
                    .HasColumnName("timer_lic")
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SolicitacaoChave>(entity =>
            {
                entity.HasKey(e => e.IdSolicitacaoChave);

                entity.ToTable("solicitacao_chave");

                entity.Property(e => e.IdSolicitacaoChave).HasColumnName("id_solicitacao_chave");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.Conta)
                    .HasColumnName("conta")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DataAgendada)
                    .HasColumnName("data_agendada")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataDevolvida)
                    .HasColumnName("data_devolvida")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataEntrega)
                    .HasColumnName("data_entrega")
                    .HasColumnType("datetime");

                entity.Property(e => e.DocumentoSol)
                    .HasColumnName("documento_sol")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Entregue).HasColumnName("entregue");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Placa)
                    .HasColumnName("placa")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Responsavel)
                    .HasColumnName("responsavel")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelefoneResp)
                    .HasColumnName("telefone_resp")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoCliente>(entity =>
            {
                entity.HasKey(e => e.IdTipoCliente);

                entity.ToTable("tipo_cliente");

                entity.Property(e => e.IdTipoCliente).HasColumnName("id_tipo_cliente");

                entity.Property(e => e.Tipocliente1)
                    .IsRequired()
                    .HasColumnName("tipocliente")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoCustoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoCustoUsuario);

                entity.ToTable("tipo_custo_usuario");

                entity.Property(e => e.IdTipoCustoUsuario).HasColumnName("id_tipo_custo_usuario");

                entity.Property(e => e.DescricaoTc)
                    .HasColumnName("descricao_tc")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoEvento>(entity =>
            {
                entity.HasKey(e => e.IdTipoEvento);

                entity.ToTable("tipo_evento");

                entity.Property(e => e.IdTipoEvento).HasColumnName("id_tipo_evento");

                entity.Property(e => e.AtendimentoManual).HasColumnName("atendimento_manual");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.DescricaoZona)
                    .HasColumnName("descricao_zona")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.Evento)
                    .HasColumnName("evento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EvtRest).HasColumnName("evtRest");

                entity.Property(e => e.Grupo)
                    .HasColumnName("grupo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdFormato).HasColumnName("id_formato");

                entity.Property(e => e.TocarSom).HasColumnName("tocar_som");

                entity.Property(e => e.Zona)
                    .HasColumnName("zona")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoManutencao>(entity =>
            {
                entity.HasKey(e => e.IdTipoManutencao);

                entity.ToTable("tipo_manutencao");

                entity.Property(e => e.IdTipoManutencao).HasColumnName("id_tipo_manutencao");

                entity.Property(e => e.NomeTipoManutencao)
                    .HasColumnName("nome_tipo_manutencao")
                    .HasMaxLength(400)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoServico>(entity =>
            {
                entity.HasKey(e => e.IdTipoServico);

                entity.ToTable("tipo_servico");

                entity.Property(e => e.IdTipoServico).HasColumnName("id_tipo_servico");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Obs)
                    .HasColumnName("obs")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoServicoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoServicoUsuario);

                entity.ToTable("tipo_servico_usuario");

                entity.Property(e => e.IdTipoServicoUsuario).HasColumnName("id_tipo_servico_usuario");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoVeiculo>(entity =>
            {
                entity.HasKey(e => e.IdTipoVeiculo);

                entity.ToTable("tipo_veiculo");

                entity.Property(e => e.IdTipoVeiculo).HasColumnName("id_tipo_veiculo");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(400)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.CodUsuario)
                    .HasColumnName("cod_usuario")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("text");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasColumnName("senha")
                    .HasColumnType("text");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Telefone)
                    .HasColumnName("telefone")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<UsuarioGestao>(entity =>
            {
                entity.HasKey(e => e.IdUsuarioGestao);

                entity.ToTable("usuario_gestao");

                entity.Property(e => e.IdUsuarioGestao).HasColumnName("id_usuario_gestao");

                entity.Property(e => e.Atividades)
                    .HasColumnName("atividades")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.DataInicio)
                    .HasColumnName("data_inicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataTermino)
                    .HasColumnName("data_termino")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdTipoServicoUsuario).HasColumnName("id_tipo_servico_usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.TempoExpediente)
                    .HasColumnName("tempo_expediente")
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Veiculo>(entity =>
            {
                entity.HasKey(e => e.IdVeiculo);

                entity.ToTable("veiculo");

                entity.Property(e => e.IdVeiculo).HasColumnName("id_veiculo");

                entity.Property(e => e.Ano)
                    .HasColumnName("ano")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.Capacidade)
                    .HasColumnName("capacidade")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cor)
                    .HasColumnName("cor")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipoVeiculo).HasColumnName("id_tipo_veiculo");

                entity.Property(e => e.Marca)
                    .HasColumnName("marca")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .HasColumnName("modelo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Passageiros)
                    .HasColumnName("passageiros")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Placa)
                    .HasColumnName("placa")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Portas)
                    .HasColumnName("portas")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Potencia)
                    .HasColumnName("potencia")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VeiculoCombustivel>(entity =>
            {
                entity.HasKey(e => e.IdVeiculoCombustivel);

                entity.ToTable("veiculo_combustivel");

                entity.Property(e => e.IdVeiculoCombustivel).HasColumnName("id_veiculo_combustivel");

                entity.Property(e => e.CustoCombustivel).HasColumnName("custo_combustivel");

                entity.Property(e => e.DataCombustivel)
                    .HasColumnName("data_combustivel")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdVeiculo).HasColumnName("id_veiculo");

                entity.Property(e => e.KmVeiculo)
                    .HasColumnName("km_veiculo")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.QtdCombustivel).HasColumnName("qtd_combustivel");
            });

            modelBuilder.Entity<VeiculoGestao>(entity =>
            {
                entity.HasKey(e => e.IdVeiculoGestao);

                entity.ToTable("veiculo_gestao");

                entity.Property(e => e.IdVeiculoGestao).HasColumnName("id_veiculo_gestao");

                entity.Property(e => e.DataChegada)
                    .HasColumnName("data_chegada")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataSaida)
                    .HasColumnName("data_saida")
                    .HasColumnType("datetime");

                entity.Property(e => e.DescricaoAtividade)
                    .HasColumnName("descricao_atividade")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdBaseRetorno).HasColumnName("id_base_retorno");

                entity.Property(e => e.IdBaseSaida).HasColumnName("id_base_saida");

                entity.Property(e => e.IdEventoMonit).HasColumnName("id_evento_monit");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.IdVeiculo).HasColumnName("id_veiculo");

                entity.Property(e => e.KmFinal)
                    .HasColumnName("km_final")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KmInical)
                    .HasColumnName("km_inical")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Monitoramento).HasColumnName("monitoramento");

                entity.Property(e => e.NivelCombustivel)
                    .HasColumnName("nivel_combustivel")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VeiculoPosicao>(entity =>
            {
                entity.HasKey(e => e.IdVeiculoPosicao);

                entity.ToTable("veiculo_posicao");

                entity.Property(e => e.IdVeiculoPosicao).HasColumnName("id_veiculo_posicao");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.IdVeiculo).HasColumnName("id_veiculo");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VeiculoPosicaoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdVeiculoPosicaoUsuario);

                entity.ToTable("veiculo_posicao_usuario");

                entity.Property(e => e.IdVeiculoPosicaoUsuario).HasColumnName("id_veiculo_posicao_usuario");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.IdBase).HasColumnName("id_base");

                entity.Property(e => e.IdTipoServico).HasColumnName("id_tipo_servico");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.IdVeiculo).HasColumnName("id_veiculo");

                entity.Property(e => e.IdVeiculoPosicao).HasColumnName("id_veiculo_posicao");
            });

            //################################################

            modelBuilder.Entity<EventoMonitoramento>()
                .HasOne(em => em.Usuario)
                .WithMany()
                .HasForeignKey(em => em.IdUsuario);

            modelBuilder.Entity<DetalhesSMEAC>()
                .HasOne(ds => ds.Usuario)
                .WithMany()
                .HasForeignKey(ds => ds.IdUsuario);

            modelBuilder.Entity<DetalhesSMEAC>()
                .HasOne(ds => ds.Veiculo)
                .WithMany()
                .HasForeignKey(ds => ds.IdVeiculo);

            //################################################

            modelBuilder.Entity<EventoEstado>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("evento_estado");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(100);

                entity.Property(e => e.CorAusente)
                    .HasColumnName("cor_ausente")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<EventoEstadoAcao>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("evento_estado_acao");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Decricao)
                    .HasColumnName("decricao")
                    .HasMaxLength(100);

                entity.Property(e => e.Cor)
                    .HasColumnName("cor")
                    .HasMaxLength(20);

                entity.Property(e => e.CodigoEvento)
                    .HasColumnName("cod_evento")
                    .HasMaxLength(20);

                entity.Property(e => e.IdEventoEstado)
                    .HasColumnName("id_evento_estado");
            });

            modelBuilder.Entity<EventoEstadoAcao>()
                .HasOne(e => e.EventoEstado)
                .WithMany()
                .HasForeignKey(e => e.IdEventoEstado);

            modelBuilder.Entity<ReceptoraAcao>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("receptora_acao");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.IdEventoEstadoAcao)
                    .HasColumnName("id_evento_estado_acao");

                entity.Property(e => e.IdReceptora)
                    .HasColumnName("id_receptora");

                entity.Property(e => e.GeraAtendimento)
                    .HasColumnName("gera_atendimento");
            });

            modelBuilder.Entity<ReceptoraAcao>()
                .HasOne(e => e.EventoEstadoAcao)
                .WithMany()
                .HasForeignKey(e => e.IdEventoEstadoAcao);

            modelBuilder.Entity<ReceptoraAcao>()
                .HasOne(e => e.Receptora)
                .WithMany()
                .HasForeignKey(e => e.IdReceptora);
            //################################################

            // No seu ApplicationDbContext, no método OnModelCreating

            //modelBuilder.Entity<ClienteMonitoramento>()
            //    .HasOne(em => em.Cliente)
            //    .WithMany()
            //    .HasForeignKey(em => em.IdCliente);

            //// Relações para EventoMonitoramento, SMEAC e DetalhesSMEAC
            //modelBuilder.Entity<EventoMonitoramento>()
            //    .HasOne(em => em.Usuario)
            //    .WithMany()
            //    .HasForeignKey(em => em.IdUsuario);

            //modelBuilder.Entity<SMEAC>()
            //    .HasOne(s => s.EventoMonitoramento) // Supondo que EventoMonitoramento pode ser navegado a partir de SMEAC
            //    .WithMany()
            //    .HasForeignKey(s => s.IdEventoMonitoramento);

            //modelBuilder.Entity<DetalhesSMEAC>()
            //    .HasOne(ds => ds.SMEAC)
            //    .WithMany(s => s.DetalhesSMEAC) // Se você adicionar uma coleção DetalhesSMEAC na classe SMEAC
            //    .HasForeignKey(ds => ds.IdSMEAC);

            //modelBuilder.Entity<DetalhesSMEAC>()
            //    .HasOne(ds => ds.Usuario)
            //    .WithMany()
            //    .HasForeignKey(ds => ds.IdUsuario);

            //modelBuilder.Entity<DetalhesSMEAC>()
            //    .HasOne(ds => ds.Veiculo)
            //    .WithMany()
            //    .HasForeignKey(ds => ds.IdVeiculo);

            // Adicione as propriedades de navegação virtuais nas suas classes DataModels:
            // Em EventoMonitoramento.cs:
            // public virtual Usuario Usuario { get; set; }
            // Em SMEAC.cs:
            // public virtual EventoMonitoramento EventoMonitoramento { get; set; }
            // public virtual ICollection<DetalhesSMEAC> DetalhesSMEAC { get; set; } // Adicione isso se ainda não tiver
            // Em DetalhesSMEAC.cs:
            // public virtual SMEAC SMEAC { get; set; }
            // public virtual Usuario Usuario { get; set; }
            // public virtual Veiculo Veiculo { get; set; }

            //################################################

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
