using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Grupo_Beira_Mar_Web_Application.Data.Migrations
{
    /// <inheritdoc />
    public partial class FKS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Particao",
                table: "cliente",
                type: "nvarchar(2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Particao",
                table: "cliente");
        }
    }
}
