using Microsoft.EntityFrameworkCore.Migrations;

namespace Grupo_Beira_Mar_Web_Application.Data.Migrations
{
    public partial class Eventos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_evento_monitoramento_id_usuario",
                table: "evento_monitoramento",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_detalhes_s_m_e_a_c_id_usuario",
                table: "detalhes_s_m_e_a_c",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_detalhes_s_m_e_a_c_id_veiculo",
                table: "detalhes_s_m_e_a_c",
                column: "id_veiculo");

            migrationBuilder.AddForeignKey(
                name: "FK_detalhes_s_m_e_a_c_usuario_id_usuario",
                table: "detalhes_s_m_e_a_c",
                column: "id_usuario",
                principalTable: "usuario",
                principalColumn: "id_usuario",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_detalhes_s_m_e_a_c_veiculo_id_veiculo",
                table: "detalhes_s_m_e_a_c",
                column: "id_veiculo",
                principalTable: "veiculo",
                principalColumn: "id_veiculo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_evento_monitoramento_usuario_id_usuario",
                table: "evento_monitoramento",
                column: "id_usuario",
                principalTable: "usuario",
                principalColumn: "id_usuario",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detalhes_s_m_e_a_c_usuario_id_usuario",
                table: "detalhes_s_m_e_a_c");

            migrationBuilder.DropForeignKey(
                name: "FK_detalhes_s_m_e_a_c_veiculo_id_veiculo",
                table: "detalhes_s_m_e_a_c");

            migrationBuilder.DropForeignKey(
                name: "FK_evento_monitoramento_usuario_id_usuario",
                table: "evento_monitoramento");

            migrationBuilder.DropIndex(
                name: "IX_evento_monitoramento_id_usuario",
                table: "evento_monitoramento");

            migrationBuilder.DropIndex(
                name: "IX_detalhes_s_m_e_a_c_id_usuario",
                table: "detalhes_s_m_e_a_c");

            migrationBuilder.DropIndex(
                name: "IX_detalhes_s_m_e_a_c_id_veiculo",
                table: "detalhes_s_m_e_a_c");
        }
    }
}
