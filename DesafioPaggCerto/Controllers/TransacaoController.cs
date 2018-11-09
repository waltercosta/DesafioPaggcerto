using Microsoft.AspNetCore.Mvc;

namespace DesafioPaggCerto.Controllers
{
    [Route("api/v1/transaction")]
    public class TransacaoController : ControllerBase
    {
        [Route("create")]
        public IActionResult Create()
        {
            return Ok();
        }
    }
}