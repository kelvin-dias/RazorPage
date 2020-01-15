using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OCORRENCIAS",
                columns: table => new
                {
                    OcorrenciaId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroOcorrencia = table.Column<long>(nullable: true),
                    Titulo = table.Column<string>(nullable: false),
                    DataHora = table.Column<DateTime>(nullable: false),
                    StatusOcorrencia = table.Column<bool>(nullable: false),
                    CriticidadeOcorrencia = table.Column<int>(nullable: false),
                    Solucao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OCORRENCIAS", x => x.OcorrenciaId);
                });

            migrationBuilder.CreateTable(
                name: "ITERACOES_OCORRENCIAS",
                columns: table => new
                {
                    IteracaoOcorrenciaId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TextoIteracao = table.Column<string>(nullable: true),
                    DataHoraIteracao = table.Column<DateTime>(nullable: false),
                    Assinatura = table.Column<string>(nullable: true),
                    OcorrenciaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITERACOES_OCORRENCIAS", x => x.IteracaoOcorrenciaId);
                    table.ForeignKey(
                        name: "FK_ITERACOES_OCORRENCIAS_OCORRENCIAS_OcorrenciaId",
                        column: x => x.OcorrenciaId,
                        principalTable: "OCORRENCIAS",
                        principalColumn: "OcorrenciaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ITERACOES_OCORRENCIAS_OcorrenciaId",
                table: "ITERACOES_OCORRENCIAS",
                column: "OcorrenciaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ITERACOES_OCORRENCIAS");

            migrationBuilder.DropTable(
                name: "OCORRENCIAS");
        }
    }
}
