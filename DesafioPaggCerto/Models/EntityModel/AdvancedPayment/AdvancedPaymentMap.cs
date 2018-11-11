using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioPaggCerto.Models.EntityModel.AdvancedPayments
{
    public static class AdvancedPaymentMap
    {
        public static void Configure(this EntityTypeBuilder<AdvancedPayment> entity)
        {
            entity.ToTable("Antecipacao", "pagamentos");

            entity.HasKey(p => p.Id);

            #region Properties
            entity.Property(p => p.Id).ValueGeneratedOnAdd();

            entity.Property(p => p.RequestedOn)
                  .HasColumnName("DataSolicitacao")
                  .IsRequired();

            entity.Property(p => p.AnalyzedOn)
                  .HasColumnName("DataInicioAnalise");

            entity.Property(p => p.AnalyzedOff)
                  .HasColumnName("DataFimAnalise");

            entity.Property(p => p.StatusRequest)
                  .HasColumnName("ResultadoAnalise");

            entity.Property(p => p.AmountRequested)
                  .HasColumnName("ValorAntecipacao")
                  .IsRequired();

            entity.Property(p => p.FullyAmountTransferred)
                  .HasColumnName("ValorRepasse")
                  .HasColumnType("decimal(8,2)");

            entity.Property(p => p.Tax)
                  .HasColumnName("Taxa")
                  .HasColumnType("decimal(8,2)")
                  .IsRequired();
            #endregion

            #region Relationships
            entity.HasMany(p => p.AmountRequestedList)
                  .WithOne(p => p.AdvancedPayment);
            #endregion
        }
    }
}
