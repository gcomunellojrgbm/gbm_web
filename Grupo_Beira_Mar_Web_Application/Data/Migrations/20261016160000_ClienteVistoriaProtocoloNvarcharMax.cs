using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Grupo_Beira_Mar_Web_Application.Data.Migrations
{
    public partial class ClienteVistoriaProtocoloNvarcharMax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "chaves", table: "detalhe_cliente",
                type: "nvarchar(max)", nullable: true,
                oldClrType: typeof(string), oldType: "varchar(20)",
                oldUnicode: false, oldMaxLength: 20, oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "endereco2", table: "detalhe_cliente",
                type: "nvarchar(max)", nullable: true,
                oldClrType: typeof(string), oldType: "varchar(50)",
                oldUnicode: false, oldMaxLength: 50, oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Impede perda de textos longos ou caracteres Unicode no rollback.
            migrationBuilder.Sql(@"
IF EXISTS (
    SELECT 1 FROM [detalhe_cliente]
    WHERE DATALENGTH(CONVERT(varchar(max), [chaves])) > 20
       OR DATALENGTH(CONVERT(varchar(max), [endereco2])) > 50
       OR CONVERT(varbinary(max), [chaves]) <>
          CONVERT(varbinary(max), CONVERT(nvarchar(max), CONVERT(varchar(max), [chaves])))
       OR CONVERT(varbinary(max), [endereco2]) <>
          CONVERT(varbinary(max), CONVERT(nvarchar(max), CONVERT(varchar(max), [endereco2])))
)
    THROW 50001, 'Rollback cancelado: existem textos incompatíveis com os limites anteriores.', 1;
");
            migrationBuilder.AlterColumn<string>(
                name: "chaves", table: "detalhe_cliente",
                type: "varchar(20)", unicode: false, maxLength: 20, nullable: true,
                oldClrType: typeof(string), oldType: "nvarchar(max)", oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "endereco2", table: "detalhe_cliente",
                type: "varchar(50)", unicode: false, maxLength: 50, nullable: true,
                oldClrType: typeof(string), oldType: "nvarchar(max)", oldNullable: true);
        }
    }
}