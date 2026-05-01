using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Grupo_Beira_Mar_Web_Application.Data.Migrations
{
    /// <inheritdoc />
    public partial class EstadoAcaoV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "evento_estado",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    cor_ausente = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evento_estado", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "evento_estado_acao",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    decricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    id_evento_estado = table.Column<int>(type: "int", nullable: false),
                    cor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    cod_evento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evento_estado_acao", x => x.id);
                    table.ForeignKey(
                        name: "FK_evento_estado_acao_evento_estado_id_evento_estado",
                        column: x => x.id_evento_estado,
                        principalTable: "evento_estado",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "receptora_acao",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_evento_estado_acao = table.Column<int>(type: "int", nullable: false),
                    id_receptora = table.Column<int>(type: "int", nullable: false),
                    gera_atendimento = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receptora_acao", x => x.id);
                    table.ForeignKey(
                        name: "FK_receptora_acao_evento_estado_acao_id_evento_estado_acao",
                        column: x => x.id_evento_estado_acao,
                        principalTable: "evento_estado_acao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_receptora_acao_receptora_id_receptora",
                        column: x => x.id_receptora,
                        principalTable: "receptora",
                        principalColumn: "IdReceptora",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_evento_estado_acao_id_evento_estado",
                table: "evento_estado_acao",
                column: "id_evento_estado");

            migrationBuilder.CreateIndex(
                name: "IX_receptora_acao_id_evento_estado_acao",
                table: "receptora_acao",
                column: "id_evento_estado_acao");

            migrationBuilder.CreateIndex(
                name: "IX_receptora_acao_id_receptora",
                table: "receptora_acao",
                column: "id_receptora");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "receptora_acao");

            migrationBuilder.DropTable(
                name: "evento_estado_acao");

            migrationBuilder.DropTable(
                name: "evento_estado");
        }
    }
}
