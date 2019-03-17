using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DemoAppInsights.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error404()
        {
            return View();
        }
    }
}