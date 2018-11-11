using DesafioPaggCerto.Models.ServiceModel;
using DesafioPaggCerto.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesafioPaggCerto.Controllers
{
    [Route("api/v1/transaction")]
    public class TransactionController : ControllerBase
    {
        [Route("create")]
        public async Task<IActionResult> Create([FromServices] PaymentDomain paymentDomain, [FromBody] PaymentViewModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            model.CardNumber = model.CardNumber.Replace(" ", "");
            model.Serialize(paymentDomain);

            return Ok(model);
        }
    }
}