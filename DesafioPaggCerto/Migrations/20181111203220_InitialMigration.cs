using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioPaggCerto.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "pagamentos");

            migrationBuilder.CreateTable(
                name: "Adquirente",
                schema: "pagamentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 255, nullable: true),
                    Taxa = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adquirente", x => x.Id);
                });

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
                    ValorRepasse = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Taxa = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Antecipacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lojista",
                schema: "pagamentos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lojista", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transacao",
                schema: "pagamentos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdShopkeeper = table.Column<long>(nullable: false),
                    DataTransacao = table.Column<DateTime>(nullable: false),
                    DataRepasse = table.Column<DateTime>(nullable: false),
                    Situacao = table.Column<bool>(nullable: false),
                    ValorTransacao = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    ValorLiquido = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    ValorRepasse = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    InstallmentAmount = table.Column<int>(nullable: false),
                    AdvancedPaymentId = table.Column<long>(nullable: true),
                    NomeCompleto = table.Column<string>(maxLength: 255, nullable: false),
                    NumeroCartao = table.Column<string>(maxLength: 16, nullable: false),
                    CodigoSerguranca = table.Column<string>(maxLength: 4, nullable: false),
                    Mes = table.Column<int>(maxLength: 2, nullable: false),
                    Ano = table.Column<int>(maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transacao_Antecipacao_AdvancedPaymentId",
                        column: x => x.AdvancedPaymentId,
                        principalSchema: "pagamentos",
                        principalTable: "Antecipacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transacao_Lojista_IdShopkeeper",
                        column: x => x.IdShopkeeper,
                        principalSchema: "pagamentos",
                        principalTable: "Lojista",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestacao",
                schema: "pagamentos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdTransaction = table.Column<long>(nullable: false),
                    ValorLiquido = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    NumeroDaParcela = table.Column<int>(nullable: false),
                    DataRepasse = table.Column<DateTime>(nullable: false),
                    Antecipado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prestacao_Transacao_IdTransaction",
                        column: x => x.IdTransaction,
                        principalSchema: "pagamentos",
                        principalTable: "Transacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prestacao_IdTransaction",
                schema: "pagamentos",
                table: "Prestacao",
                column: "IdTransaction");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_AdvancedPaymentId",
                schema: "pagamentos",
                table: "Transacao",
                column: "AdvancedPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_IdShopkeeper",
                schema: "pagamentos",
                table: "Transacao",
                column: "IdShopkeeper");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adquirente",
                schema: "pagamentos");

            migrationBuilder.DropTable(
                name: "Prestacao",
                schema: "pagamentos");

            migrationBuilder.DropTable(
                name: "Transacao",
                schema: "pagamentos");

            migrationBuilder.DropTable(
                name: "Antecipacao",
                schema: "pagamentos");

            migrationBuilder.DropTable(
                name: "Lojista",
                schema: "pagamentos");
        }
    }
}
