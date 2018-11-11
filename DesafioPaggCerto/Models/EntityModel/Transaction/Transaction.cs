using System;
using DesafioPaggCerto.Models.EntityModel.AdvancedPayments;
using DesafioPaggCerto.Models.EntityModel.Shopkeepers;

namespace DesafioPaggCerto.Models.EntityModel.Transactions
{
    public class Transaction
    {
        public long Id { get; set; }
        public long IdShopkeeper { get; set; }
        public Shopkeeper Shopkeeper { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime PassedOnAt { get; set; }
        public bool Situation { get; set; }
        public decimal Amount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal PassedOnAmount { get; set; }
        public int InstallmentAmount { get; set; }
        public AdvancedPayment AdvancedPayment { get; set; }
        public string FullName { get; set; }
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
