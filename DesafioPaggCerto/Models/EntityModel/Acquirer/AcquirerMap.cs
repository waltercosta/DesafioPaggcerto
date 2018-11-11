using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioPaggCerto.Models.EntityModel.Acquirer
{
    public static class AcquirerMap
    {
        public static void Configure(this EntityTypeBuilder<Acquirer> entity)
        {
            entity.ToTable("Adquirente", "pagamentos");

            entity.HasKey(p => p.Id);

            #region Properties
            entity.Property(p => p.Id).ValueGeneratedOnAdd();

            entity.Property(p => p.Name)
                .HasColumnName("Nome")
                .HasMaxLength(255);

            entity.Property(p => p.Tax)
                .HasColumnName("Taxa")
                .HasColumnType("decimal(8,2)");
            #endregion
        }
    }
}
