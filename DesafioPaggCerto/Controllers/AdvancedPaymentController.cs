using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioPaggCerto.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPaggCerto.Controllers
{
    [Route("api/v1/advancedpayment")]
    public class AdvancedPaymentController : Controller
    {
        [Route("create"), HttpPost]
        public IActionResult Index()
        {
            return View();
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
    }
}