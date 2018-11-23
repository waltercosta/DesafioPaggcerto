using DesafioPaggCerto.Models.ServiceModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioPaggCerto.Models.ViewModel
{
    public class AntecipatedAnalyzeViewModel
    {
        [Required]
        public long? Id { get; set; }

        public AdvancedPaymentDomain Serialize(AdvancedPaymentDomain advancedPaymentDomain)
        {
            advancedPaymentDomain.Id = Id.Value;
            return advancedPaymentDomain;
        }
    }
}
