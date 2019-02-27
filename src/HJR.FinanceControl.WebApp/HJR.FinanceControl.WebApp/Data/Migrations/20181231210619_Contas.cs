using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HJR.FinanceControl.WebApp.Data.Migrations
{
    public partial class Contas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContasAPagar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Documento = table.Column<int>(nullable: false),
                    DescricaoDocumento = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    DataVencimento = table.Column<DateTime>(nullable: false),
                    ValorTotal = table.Column<double>(type: "float", nullable: false),
                    Situacao = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Fornecedor = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasAPagar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContasAReceber",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Documento = table.Column<int>(nullable: false),
                    DescricaoDocumento = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    DataVencimento = table.Column<DateTime>(nullable: false),
                    ValorTotal = table.Column<float>(nullable: false),
                    Situacao = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Cliente = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasAReceber", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContasAPagar");

            migrationBuilder.DropTable(
                name: "ContasAReceber");
        }
    }
}
