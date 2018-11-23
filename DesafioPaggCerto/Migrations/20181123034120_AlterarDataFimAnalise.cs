using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioPaggCerto.Migrations
{
    public partial class AlterarDataFimAnalise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ValorRepasse",
                schema: "pagamentos",
                table: "Antecipacao",
                type: "decimal(8,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicioAnalise",
                schema: "pagamentos",
                table: "Antecipacao",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFimAnalise",
                schema: "pagamentos",
                table: "Antecipacao",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ValorRepasse",
                schema: "pagamentos",
                table: "Antecipacao",
                type: "decimal(8,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicioAnalise",
                schema: "pagamentos",
                table: "Antecipacao",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFimAnalise",
                schema: "pagamentos",
                table: "Antecipacao",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
