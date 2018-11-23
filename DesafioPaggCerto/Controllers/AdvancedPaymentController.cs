using System.Linq;
using System.Threading.Tasks;
using DesafioPaggCerto.Infrastructure.Context;
using DesafioPaggCerto.Models.ServiceModel;
using DesafioPaggCerto.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPaggCerto.Controllers
{
    [Route("api/v1/advancedpayment")]
    public class AdvancedPaymentController : Controller
    {
        [Route("create"), HttpPost]
        public async Task<IActionResult> Create([FromServices] AdvancedPaymentDomain advancedPaymentDomain, [FromBody] AdvancedPaymentViewModel advancedPaymentViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            advancedPaymentViewModel.Serialize(advancedPaymentDomain);
            
            if(!await advancedPaymentDomain.Advanced())
            {
                return UnprocessableEntity(new { Error = "Falha ao registrar antecipação" });
            }

            return Ok(advancedPaymentDomain.AdvancedPayment);
            
        }


        [Route("list"), HttpGet]
        public async Task<IActionResult> List([FromServices] DesafioContext desafioContext, [FromQuery] bool isAdvencedPaymented)
        {
            var list = desafioContext.Transactions
                .Where(transaction => (isAdvencedPaymented && transaction.PassedOnAt == null) || (!isAdvencedPaymented))
                .ToList()
                .OrderByDescending(p => p.CreatedAt);

            return Ok(list);
        }

        [Route("underanalysis"), HttpPost]
        public async Task<IActionResult> UnderAnalysis([FromServices] AdvancedPaymentDomain advancedPaymentDomain, [FromBody] AntecipatedAnalyzeViewModel antecipatedAnalyzeViewModel)
        {
            antecipatedAnalyzeViewModel.Serialize(advancedPaymentDomain);

            var result = await advancedPaymentDomain.UpdateAntecipateToUnderAnalysis();

            if (!result)
                return UnprocessableEntity(new { Error = "Antecipação não existe ou não pode ser alterada" });

            return Ok();
        }

        [Route("analyzed"), HttpPost]
        public async Task<IActionResult> Analyzed([FromServices] AdvancedPaymentDomain advancedPaymentDomain, [FromBody] AntecipatedAnalyzeViewModel antecipatedAnalyzeViewModel)
        {
            antecipatedAnalyzeViewModel.Serialize(advancedPaymentDomain);

            var result = await advancedPaymentDomain.UpdateAntecipateToAnalyzed();

            if (!result)
                return UnprocessableEntity(new { Error = "Antecipação não existe ou não pode ser alterada" });

            return Ok();
        }
    }
}