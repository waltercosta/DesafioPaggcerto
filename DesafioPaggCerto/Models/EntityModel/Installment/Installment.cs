using DesafioPaggCerto.Models.EntityModel.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioPaggCerto.Models.EntityModel.Installments
{
    public class Installment
    {
        public long Id { get; set; }
        public long IdTransaction { get; set; }
        public Transaction Transaction { get; set; }
        public decimal NetAmount { get; set; }
        public decimal Amount { get; set; }
        public int Number { get; set; }
        public DateTime PassedOn { get; set; }
        public bool IsAntecipated { get; set; }

    }
}
