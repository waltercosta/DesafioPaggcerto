using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioPaggCerto.Models.EntityModel.Installments
{
    public static class InstallmentMap
    {
        public static void Configure (this EntityTypeBuilder<Installment> entity)
        {
            entity.ToTable("Prestacao", "pagamentos");

            entity.HasKey(p => p.Id);

            #region Properties
            entity.Property(p => p.Id).ValueGeneratedOnAdd();

            entity.Property(p => p.NetAmount)
                  .HasColumnName("ValorLiquido")
                  .HasColumnType("decimal(8,2)");

            entity.Property(p => p.Amount)
                  .HasColumnName("ValorTotal")
                  .HasColumnType("decimal(8,2)");

            entity.Property(p => p.Number)
                  .HasColumnName("NumeroDaParcela");

            entity.Property(p => p.PassedOn)
                  .HasColumnName("DataRepasse")
                  .IsRequired();

            entity.Property(p => p.IsAntecipated)
                  .HasColumnName("Antecipado")
                  .IsRequired();
            #endregion

            entity.HasOne(p => p.Transaction)
                  .WithMany()
                  .HasForeignKey(p =>p.IdTransaction);
        }
    }
}
