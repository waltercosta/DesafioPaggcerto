using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioPaggCerto.Models.EntityModel.Shopkeepers
{
    public static class ShopkeeperMap
    {
        public static void Configure (this EntityTypeBuilder<Shopkeeper> entity)
        {
            entity.ToTable("Lojista", "pagamentos");

            entity.HasKey(p => p.Id);

            #region Properties
            entity.Property(p => p.Id).ValueGeneratedOnAdd();

            entity.Property(p => p.Name)
                  .HasColumnName("Nome");
            #endregion
        }
    }
}
