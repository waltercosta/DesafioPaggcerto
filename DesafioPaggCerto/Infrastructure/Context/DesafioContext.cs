using DesafioPaggCerto.Models.EntityModel.Acquirer;
using DesafioPaggCerto.Models.EntityModel.AdvancedPayments;
using DesafioPaggCerto.Models.EntityModel.Installments;
using DesafioPaggCerto.Models.EntityModel.Shopkeepers;
using DesafioPaggCerto.Models.EntityModel.Transactions;
using Microsoft.EntityFrameworkCore;

namespace DesafioPaggCerto.Infrastructure.Context
{
    public class DesafioContext : DbContext
    {
        public DbSet<Acquirer> Acquirers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<AdvancedPayment> AdvancePayments { get; set; }
        public DbSet<Installment> Installments { get; set; }
        public DbSet<Shopkeeper> Shopkeepers { get; set; }

        public DesafioContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acquirer>().Configure();
            modelBuilder.Entity<Transaction>().Configure();
            modelBuilder.Entity<AdvancedPayment>().Configure();
            modelBuilder.Entity<Installment>().Configure();
            modelBuilder.Entity<Shopkeeper>().Configure();
        }
    }
}
