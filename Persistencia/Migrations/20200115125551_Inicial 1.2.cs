using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
    public partial class Inicial12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataHora",
                table: "OCORRENCIAS");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraAbertura",
                table: "OCORRENCIAS",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraOcorrencia",
                table: "OCORRENCIAS",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "OCORRENCIAS",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataHoraAbertura",
                table: "OCORRENCIAS");

            migrationBuilder.DropColumn(
                name: "DataHoraOcorrencia",
                table: "OCORRENCIAS");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "OCORRENCIAS");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHora",
                table: "OCORRENCIAS",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
