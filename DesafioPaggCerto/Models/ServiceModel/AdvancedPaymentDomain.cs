using DesafioPaggCerto.Infrastructure.Context;
using DesafioPaggCerto.Models.EntityModel.AdvancedPayments;
using DesafioPaggCerto.Models.EntityModel.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioPaggCerto.Models.ServiceModel
{
    public class AdvancedPaymentDomain
    {
        private readonly DesafioContext _desafioContext;

        public AdvancedPaymentDomain (DesafioContext desafioContext)
        {
            _desafioContext = desafioContext;
        }

        public long Id { get; set; }
        public DateTime RequestedOn { get; set; }
        public DateTime? AnalyzedOn { get; set; }
        public DateTime? AnalyzedOff { get; set; }
        public string StatusRequest { get; set; }
        public decimal AmountRequested { get; set; }
        public decimal? FullyAmountTransferred { get; set; }
        public ICollection<Transaction> AmountRequestedList { get; set; }
        public decimal Tax { get; set; }
        public AdvancedPayment AdvancedPayment { get; set; }

        public async Task<bool> Advanced()
        {
            AdvancedPayment = new AdvancedPayment();

            AdvancedPayment.RequestedOn = RequestedOn;
            AdvancedPayment.AnalyzedOn = null;
            AdvancedPayment.AnalyzedOff = null;
            AdvancedPayment.StatusRequest = StatusRequest;
            AdvancedPayment.AmountRequested = AmountRequested;
            AdvancedPayment.Tax = 3.8M;

            try
            {
                if (!IsExistsTransactions())
                    return false;

                AdvancedPayment.AmountRequested = AmountRequestedList.Sum(p => p.Amount);
                AdvancedPayment.FullyAmountTransferred = AmountRequestedList.Sum(p => p.NetAmount) - 0.9M;

                _desafioContext.AdvancePayments.Add(AdvancedPayment);
                await _desafioContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool IsExistsTransactions()
        {
            var count = AmountRequestedList.Count();

            AmountRequestedList = _desafioContext.Transactions
                 .Where(p => AmountRequestedList.Select(x => x.Id).Contains(p.Id)).ToList();

            return count == AmountRequestedList.Count();
        }

        public async Task<bool> UpdateAntecipateToUnderAnalysis()
        {
            var antecipate = await _desafioContext.AdvancePayments.FindAsync(Id);

            if (antecipate == null)
                return false;

            antecipate.AnalyzedOn = DateTime.Now;
            antecipate.StatusRequest = "processing";

            _desafioContext.AdvancePayments.Update(antecipate);

            await _desafioContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAntecipateToAnalyzed()
        {
            var antecipate = await _desafioContext.AdvancePayments.FindAsync(Id);

            if (antecipate == null)
                return false;

            antecipate.AnalyzedOn = DateTime.Now;
            antecipate.StatusRequest = "analyzed";

            _desafioContext.AdvancePayments.Update(antecipate);

            await _desafioContext.SaveChangesAsync();

            return true;
        }

    }
}
