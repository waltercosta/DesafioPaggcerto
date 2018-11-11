using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPaggCerto.Controllers
{
    public class AdvancedPaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}