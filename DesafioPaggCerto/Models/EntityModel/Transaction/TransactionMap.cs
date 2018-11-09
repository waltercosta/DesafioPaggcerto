using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioPaggCerto.Models.EntityModel.Transactions
{
    public static class TransactionMap
    {
        public static void Configure(this EntityTypeBuilder<Transaction> entity)
        {
            #region ToTable
            entity.ToTable("Transacao", "pagamentos");
            #endregion

            #region Keys
            entity.HasKey(p => p.Id);
            #endregion

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
                  .IsRequired();

            entity.Property(p => p.NetAmount)
                  .HasColumnName("ValorLiquido");

            entity.Property(p => p.PassedOnAmount)
                  .HasColumnName("ValorRepasse");

            entity.Property(p => p.Installment)
                  .HasColumnName("NumeroParcelas")
                  .IsRequired();
            #endregion


        }
    }
}
