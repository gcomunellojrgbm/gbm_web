using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Grupo_Beira_Mar_Web_Application.Data.Migrations
{
    public partial class ClienteInteracaoNvarcharMax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "obs_contato",
                table: "cliente",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldUnicode: false,
                oldMaxLength: 300,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Evita truncar textos ou perder caracteres Unicode em um rollback.
            migrationBuilder.Sql(@"
IF EXISTS (
    SELECT 1 FROM [cliente]
    WHERE DATALENGTH(CONVERT(varchar(max), [obs_contato])) > 300
       OR CONVERT(varbinary(max), [obs_contato]) <>
          CONVERT(varbinary(max), CONVERT(nvarchar(max), CONVERT(varchar(max), [obs_contato])))
)
    THROW 50001, 'Rollback cancelado: existem interações incompatíveis com varchar(300).', 1;
");
            migrationBuilder.AlterColumn<string>(
                name: "obs_contato",
                table: "cliente",
                type: "varchar(300)",
                unicode: false,
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}