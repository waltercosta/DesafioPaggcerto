using DesafioPaggCerto.Extensions;
using DesafioPaggCerto.Infrastructure.Context;
using DesafioPaggCerto.Models.EntityModel.Transactions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioPaggCerto.Models.ServiceModel
{
    public class PaymentDomain
    {
        private readonly DesafioContext _desafioContext;

        public PaymentDomain(DesafioContext desafioContext)
        {
            _desafioContext = desafioContext;
        }

        public string CardNumber { get; set; }
        public string Cvv { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public string FullName { get; set; }
        public decimal? PurchaseValue { get; set; }
        public int? Installment { get; set; }
        public long? IdShopKeeper { get; set; }
        public Transaction Transaction { get; set; }

        public async Task<bool> Pay()
        {
            Transaction = new Transaction();
            
            Transaction.CardNumber = CardNumber.CardMask();
            Transaction.Cvv = Cvv;
            Transaction.Month = Month.Value;
            Transaction.Year = Year.Value;
            Transaction.FullName = FullName;
            Transaction.Amount = PurchaseValue.Value ;
            Transaction.Installment = Installment.Value;
            Transaction.IdShopkeeper = IdShopKeeper.Value;
            Transaction.Situation = true;
            Transaction.CreatedAt = DateTime.Now;

            var acquirer = _desafioContext.Acquirers.SingleOrDefault(p => p.Id == 1);

            if (acquirer == null) return false;

            Transaction.NetAmount = PurchaseValue.Value - (PurchaseValue.Value * (acquirer.Tax/100));

            _desafioContext.Transactions.Add(Transaction);

            try
            {
            await _desafioContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
