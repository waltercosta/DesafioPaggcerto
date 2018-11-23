using DesafioPaggCerto.Models.EntityModel.Transactions;
using DesafioPaggCerto.Models.ServiceModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioPaggCerto.Models.ViewModel
{
    public class AdvancedPaymentViewModel
    {
        [Required]
        public ICollection<Transaction> AmountRequestedList { get; set; }

        public AdvancedPaymentDomain Serialize(AdvancedPaymentDomain advancedPaymentDomain)
        {
            advancedPaymentDomain.RequestedOn = DateTime.Now;
            advancedPaymentDomain.StatusRequest = "pending";
            advancedPaymentDomain.AmountRequestedList = AmountRequestedList;

            return advancedPaymentDomain;
        }
    }
}
