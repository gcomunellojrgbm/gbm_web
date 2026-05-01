using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Grupo_Beira_Mar_Web_Application.Data.Migrations
{
    /// <inheritdoc />
    public partial class ClienteReceptora : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_receptora",
                table: "cliente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_cliente_id_receptora",
                table: "cliente",
                column: "id_receptora");

            migrationBuilder.AddForeignKey(
                name: "FK_cliente_receptora_id_receptora",
                table: "cliente",
                column: "id_receptora",
                principalTable: "receptora",
                principalColumn: "IdReceptora",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cliente_receptora_id_receptora",
                table: "cliente");

            migrationBuilder.DropIndex(
                name: "IX_cliente_id_receptora",
                table: "cliente");

            migrationBuilder.DropColumn(
                name: "id_receptora",
                table: "cliente");
        }
    }
}
