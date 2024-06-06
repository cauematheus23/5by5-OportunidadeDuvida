using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OportunidadeAPI.Migrations
{
    public partial class InitialCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Oportunidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NivelSurto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QtdHoras = table.Column<int>(type: "int", nullable: false),
                    QtdErros = table.Column<long>(type: "bigint", nullable: false),
                    AprendizadoNivel = table.Column<long>(type: "bigint", nullable: false),
                    HorasDeSono = table.Column<long>(type: "bigint", nullable: false),
                    HorasFolga = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oportunidade", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Oportunidade");
        }
    }
}
