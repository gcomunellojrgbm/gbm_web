using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Grupo_Beira_Mar_Web_Application.Data.Migrations
{
    /// <inheritdoc />
    public partial class Receptora : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "receptora",
                columns: table => new
                {
                    IdReceptora = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receptora", x => x.IdReceptora);
                });

            migrationBuilder.CreateTable(
                name: "receptora_evento",
                columns: table => new
                {
                    IdEvento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    evento = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    id_receptora = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receptora_evento", x => x.IdEvento);
                    table.ForeignKey(
                        name: "FK_receptora_evento_receptora_id_receptora",
                        column: x => x.id_receptora,
                        principalTable: "receptora",
                        principalColumn: "IdReceptora",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_receptora_evento_id_receptora",
                table: "receptora_evento",
                column: "id_receptora");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "receptora_evento");

            migrationBuilder.DropTable(
                name: "receptora");
        }
    }
}
