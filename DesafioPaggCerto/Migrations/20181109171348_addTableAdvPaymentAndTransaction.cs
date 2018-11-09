using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioPaggCerto.Migrations
{
    public partial class addTableAdvPaymentAndTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Taxa",
                schema: "pagamentos",
                table: "Adquirente",
                type: "decimal(8,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14,2)");

            migrationBuilder.CreateTable(
                name: "Antecipacao",
                schema: "pagamentos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataSolicitacao = table.Column<DateTime>(nullable: false),
                    DataInicioAnalise = table.Column<DateTime>(nullable: false),
                    DataFimAnalise = table.Column<DateTime>(nullable: false),
                    ResultadoAnalise = table.Column<string>(nullable: true),
                    ValorAntecipacao = table.Column<decimal>(nullable: false),
                    ValorRepasse = table.Column<decimal>(nullable: false),
                    Taxa = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Antecipacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transacao",
                schema: "pagamentos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataTransacao = table.Column<DateTime>(nullable: false),
                    DataRepasse = table.Column<DateTime>(nullable: false),
                    Situacao = table.Column<bool>(nullable: false),
                    ValorTransacao = table.Column<decimal>(nullable: false),
                    ValorLiquido = table.Column<decimal>(nullable: false),
                    ValorRepasse = table.Column<decimal>(nullable: false),
                    NumeroParcelas = table.Column<int>(nullable: false),
                    AdvancePaymentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transacao_Antecipacao_AdvancePaymentId",
                        column: x => x.AdvancePaymentId,
                        principalSchema: "pagamentos",
                        principalTable: "Antecipacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_AdvancePaymentId",
                schema: "pagamentos",
                table: "Transacao",
                column: "AdvancePaymentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacao",
                schema: "pagamentos");

            migrationBuilder.DropTable(
                name: "Antecipacao",
                schema: "pagamentos");

            migrationBuilder.AlterColumn<decimal>(
                name: "Taxa",
                schema: "pagamentos",
                table: "Adquirente",
                type: "decimal(14,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)");
        }
    }
}
