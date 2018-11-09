using DesafioPaggCerto.Models.EntityModel.Acquirer;
using DesafioPaggCerto.Models.EntityModel.AdvancePayments;
using DesafioPaggCerto.Models.EntityModel.Transactions;
using Microsoft.EntityFrameworkCore;

namespace DesafioPaggCerto.Infrastructure.Context
{
    public class DesafioContext : DbContext
    {
        DbSet<Acquirer> Acquirers { get; set; }
        DbSet<Transaction> Transactions { get; set; }
        DbSet<AdvancePayment> AdvancePayments { get; set; }

        public DesafioContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acquirer>().Configure();
            modelBuilder.Entity<Transaction>().Configure();
            modelBuilder.Entity<AdvancePayment>().Configure();
        }
    }
}
