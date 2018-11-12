using DesafioPaggCerto.Models.ServiceModel;
using System.ComponentModel.DataAnnotations;

namespace DesafioPaggCerto.Models.ViewModel
{
    public class PaymentViewModel
    {
        [Required, CreditCard]
        public string CardNumber { get; set; }
        [Required, MinLength(3), MaxLength(4)]
        public string Cvv { get; set; }
        [Required, Range(1, 12)]
        public int? Month { get; set; }
        [Required, Range(2018, 2100)]
        public int? Year { get; set; }
        [Required, MinLength(3), MaxLength(255)]
        public string FullName { get; set; }
        [Required]
        public decimal? PurchaseValue { get; set; }
        [Required, Range (1, 12)]
        public int? Installment { get; set; }
        [Required]
        public long? IdShopKeeper { get; set; }

        public PaymentDomain Serialize(PaymentDomain paymentDomain)
        {
            paymentDomain.CardNumber = CardNumber;
            paymentDomain.Cvv = Cvv;
            paymentDomain.Month = Month;
            paymentDomain.Year = Year;
            paymentDomain.FullName = FullName;
            paymentDomain.Installment = Installment;
            paymentDomain.IdShopKeeper = IdShopKeeper;

            return paymentDomain;
        }
    }
}
