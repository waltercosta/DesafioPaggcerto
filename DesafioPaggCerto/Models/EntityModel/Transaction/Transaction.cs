using System;
using DesafioPaggCerto.Models.EntityModel.AdvancePayments;

namespace DesafioPaggCerto.Models.EntityModel.Transactions
{
    public class Transaction
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime PassedOnAt { get; set; }
        public bool Situation { get; set; }
        public decimal Amount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal PassedOnAmount { get; set; }
        public int Installment { get; set; }
        public AdvancePayment AdvancePayment { get; set; }
    }
}
