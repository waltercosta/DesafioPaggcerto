using DesafioPaggCerto.Models.EntityModel.Transactions;
using System;
using System.Collections.Generic;

namespace DesafioPaggCerto.Models.EntityModel.AdvancedPayments
{
    public class AdvancedPayment
    {
        public long Id { get; set; }
        public DateTime RequestedOn { get; set; }
        public DateTime AnalyzedOn { get; set; }
        public DateTime AnalyzedOff { get; set; }
        public string StatusRequest { get; set; }
        public decimal AmountRequested { get; set; }
        public decimal FullyAmountTransferred { get; set; }
        public ICollection<Transaction> AmountRequestedList { get; set; }
        public decimal Tax { get; set; }
    }
}
