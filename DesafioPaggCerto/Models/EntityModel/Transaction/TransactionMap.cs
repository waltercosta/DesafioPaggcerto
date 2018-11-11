using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioPaggCerto.Models.EntityModel.Transactions
{
    public static class TransactionMap
    {
        public static void Configure(this EntityTypeBuilder<Transaction> entity)
        {
            entity.ToTable("Transacao", "pagamentos");

            entity.HasKey(p => p.Id);

            #region Properties
            entity.Property(p => p.Id).ValueGeneratedOnAdd();

            entity.Property(p => p.CreatedAt)
                  .HasColumnName("DataTransacao");

            entity.Property(p => p.PassedOnAt)
                  .HasColumnName("DataRepasse");

            entity.Property(p => p.Situation)
                  .HasColumnName("Situacao");

            entity.Property(p => p.Amount)
                  .HasColumnName("ValorTransacao")
                  .HasColumnType("decimal(8,2)")
                  .IsRequired();

            entity.Property(p => p.NetAmount)
                  .HasColumnName("ValorLiquido")
                  .HasColumnType("decimal(8,2)");

            entity.Property(p => p.PassedOnAmount)
                  .HasColumnName("ValorRepasse")
                  .HasColumnType("decimal(8,2)");
            
            entity.Property(p => p.FullName)
                  .HasColumnName("NomeCompleto")
                  .HasMaxLength(255)
                  .IsRequired();

            entity.Property(p => p.CardNumber)
                  .HasColumnName("NumeroCartao")
                  .HasMaxLength(16)
                  .IsRequired();

            entity.Property(p => p.Cvv)
                  .HasColumnName("CodigoSerguranca")
                  .HasMaxLength(4)
                  .IsRequired();

            entity.Property(p => p.Month)
                  .HasColumnName("Mes")
                  .HasMaxLength(2)
                  .IsRequired();

            entity.Property(p => p.Year)
                  .HasColumnName("Ano")
                  .HasMaxLength(4)
                  .IsRequired();
            #endregion

            entity.HasOne(p => p.Shopkeeper)
                  .WithMany()
                  .HasForeignKey(p => p.IdShopkeeper);
        }
    }
}
