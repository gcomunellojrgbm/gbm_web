using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Grupo_Beira_Mar_Web_Application.Data.Migrations
{
    /// <inheritdoc />
    public partial class Evento_idEventoEstado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_evento_estado",
                table: "evento",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_evento_id_evento_estado",
                table: "evento",
                column: "id_evento_estado");

            migrationBuilder.AddForeignKey(
                name: "FK_evento_evento_estado_id_evento_estado",
                table: "evento",
                column: "id_evento_estado",
                principalTable: "evento_estado",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_evento_evento_estado_id_evento_estado",
                table: "evento");

            migrationBuilder.DropIndex(
                name: "IX_evento_id_evento_estado",
                table: "evento");

            migrationBuilder.DropColumn(
                name: "id_evento_estado",
                table: "evento");
        }
    }
}
