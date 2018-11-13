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

            modelBuilder.Entity("DesafioPaggCerto.Models.EntityModel.AdvancedPayments.AdvancedPayment", b =>
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
                        .HasColumnName("ValorRepasse")
                        .HasColumnType("decimal(8,2)");

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

            modelBuilder.Entity("DesafioPaggCerto.Models.EntityModel.Installments.Installment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnName("ValorTotal")
                        .HasColumnType("decimal(8,2)");

                    b.Property<long>("IdTransaction");

                    b.Property<bool>("IsAntecipated")
                        .HasColumnName("Antecipado");

                    b.Property<decimal>("NetAmount")
                        .HasColumnName("ValorLiquido")
                        .HasColumnType("decimal(8,2)");

                    b.Property<int>("Number")
                        .HasColumnName("NumeroDaParcela");

                    b.Property<DateTime>("PassedOn")
                        .HasColumnName("DataRepasse");

                    b.HasKey("Id");

                    b.HasIndex("IdTransaction");

                    b.ToTable("Prestacao","pagamentos");
                });

            modelBuilder.Entity("DesafioPaggCerto.Models.EntityModel.Shopkeepers.Shopkeeper", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Lojista","pagamentos");
                });

            modelBuilder.Entity("DesafioPaggCerto.Models.EntityModel.Transactions.Transaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AdvancedPaymentId");

                    b.Property<decimal>("Amount")
                        .HasColumnName("ValorTransacao")
                        .HasColumnType("decimal(8,2)");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnName("NumeroCartao")
                        .HasMaxLength(16);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("DataTransacao");

                    b.Property<string>("Cvv")
                        .IsRequired()
                        .HasColumnName("CodigoSerguranca")
                        .HasMaxLength(4);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnName("NomeCompleto")
                        .HasMaxLength(255);

                    b.Property<long>("IdShopkeeper");

                    b.Property<int>("Installment");

                    b.Property<int>("Month")
                        .HasColumnName("Mes")
                        .HasMaxLength(2);

                    b.Property<decimal>("NetAmount")
                        .HasColumnName("ValorLiquido")
                        .HasColumnType("decimal(8,2)");

                    b.Property<decimal?>("PassedOnAmount")
                        .HasColumnName("ValorRepasse")
                        .HasColumnType("decimal(8,2)");

                    b.Property<DateTime?>("PassedOnAt")
                        .HasColumnName("DataRepasse");

                    b.Property<bool>("Situation")
                        .HasColumnName("Situacao");

                    b.Property<int>("Year")
                        .HasColumnName("Ano")
                        .HasMaxLength(4);

                    b.HasKey("Id");

                    b.HasIndex("AdvancedPaymentId");

                    b.HasIndex("IdShopkeeper");

                    b.ToTable("Transacao","pagamentos");
                });

            modelBuilder.Entity("DesafioPaggCerto.Models.EntityModel.Installments.Installment", b =>
                {
                    b.HasOne("DesafioPaggCerto.Models.EntityModel.Transactions.Transaction", "Transaction")
                        .WithMany()
                        .HasForeignKey("IdTransaction")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DesafioPaggCerto.Models.EntityModel.Transactions.Transaction", b =>
                {
                    b.HasOne("DesafioPaggCerto.Models.EntityModel.AdvancedPayments.AdvancedPayment", "AdvancedPayment")
                        .WithMany("AmountRequestedList")
                        .HasForeignKey("AdvancedPaymentId");

                    b.HasOne("DesafioPaggCerto.Models.EntityModel.Shopkeepers.Shopkeeper", "Shopkeeper")
                        .WithMany()
                        .HasForeignKey("IdShopkeeper")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
