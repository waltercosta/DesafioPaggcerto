using DesafioPaggCerto.Infrastructure.Context;
using DesafioPaggCerto.Models.ServiceModel;
using DesafioPaggCerto.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioPaggCerto.Controllers
{
    [Route("api/v1/transaction")]
    public class TransactionController : ControllerBase
    {
        [Route("create"), HttpPost]
        public async Task<IActionResult> Create([FromServices] PaymentDomain paymentDomain, [FromBody] PaymentViewModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            model.CardNumber = model.CardNumber.Replace(" ", "");
            model.Serialize(paymentDomain);

            if (!await paymentDomain.Pay())
            {
                return UnprocessableEntity(new { Error = "Falha ao registrar pagamento" });
            }

            return Ok(paymentDomain.Transaction);
        }

        [Route("list"), HttpGet]
        public async Task<IActionResult> List([FromServices] DesafioContext desafioContext)
        {       
            return Ok(desafioContext.Transactions.ToList().OrderByDescending(p => p.CreatedAt));
        }
    }
}