﻿// <auto-generated />
using System;
using DesafioPaggCerto.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DesafioPaggCerto.Migrations
{
    [DbContext(typeof(DesafioContext))]
    partial class DesafioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DesafioPaggCerto.Models.EntityModel.Acquirer.Acquirer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnName("Nome")
                        .HasMaxLength(255);

                    b.Property<decimal>("Tax")
                        .HasColumnName("Taxa")
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("Id");

                    b.ToTable("Adquirente","pagamentos");
                });

            modelBuilder.Entity("DesafioPaggCerto.Models.EntityModel.AdvancePayments.AdvancePayment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AmountRequested")
                        .HasColumnName("ValorAntecipacao");

                    b.Property<DateTime>("AnalyzedOff")
                        .HasColumnName("DataFimAnalise");

                    b.Property<DateTime>("AnalyzedOn")
                        .HasColumnName("DataInicioAnalise");

                    b.Property<decimal>("FullyAmountTransferred")
                        .HasColumnName("ValorRepasse");

                    b.Property<DateTime>("RequestedOn")
                        .HasColumnName("DataSolicitacao");

                    b.Property<string>("StatusRequest")
                        .HasColumnName("ResultadoAnalise");

                    b.Property<decimal>("Tax")
                        .HasColumnName("Taxa")
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("Id");

                    b.ToTable("Antecipacao","pagamentos");
                });

            modelBuilder.Entity("DesafioPaggCerto.Models.EntityModel.Transactions.Transaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AdvancePaymentId");

                    b.Property<decimal>("Amount")
                        .HasColumnName("ValorTransacao");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("DataTransacao");

                    b.Property<int>("Installment")
                        .HasColumnName("NumeroParcelas");

                    b.Property<decimal>("NetAmount")
                        .HasColumnName("ValorLiquido");

                    b.Property<decimal>("PassedOnAmount")
                        .HasColumnName("ValorRepasse");

                    b.Property<DateTime>("PassedOnAt")
                        .HasColumnName("DataRepasse");

                    b.Property<bool>("Situation")
                        .HasColumnName("Situacao");

                    b.HasKey("Id");

                    b.HasIndex("AdvancePaymentId");

                    b.ToTable("Transacao","pagamentos");
                });

            modelBuilder.Entity("DesafioPaggCerto.Models.EntityModel.Transactions.Transaction", b =>
                {
                    b.HasOne("DesafioPaggCerto.Models.EntityModel.AdvancePayments.AdvancePayment", "AdvancePayment")
                        .WithMany("AmountRequestedList")
                        .HasForeignKey("AdvancePaymentId");
                });
#pragma warning restore 612, 618
        }
    }
}
