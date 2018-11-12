using DesafioPaggCerto.Extensions;
using DesafioPaggCerto.Infrastructure.Context;
using DesafioPaggCerto.Models.EntityModel.Transactions;
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

        public async Task Pay()
        {
            var transaction = new Transaction();
            transaction.CardNumber = CardNumber.CardMask();
            transaction.Cvv = Cvv;
            transaction.Month = Month.Value;
            transaction.Year = Year.Value;
            transaction.FullName = FullName;
            transaction.Amount = PurchaseValue.Value ;
            transaction.Installment = Installment.Value;


            var acquirer = await _desafioContext.Acquirers.FindAsync(1);

            transaction.NetAmount = PurchaseValue.Value - (PurchaseValue.Value * (acquirer.Tax/100));
        }
    }
}
