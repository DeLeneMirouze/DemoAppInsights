using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoAppInsights.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsiderController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Insider a été invoqué.";
        }
    }
}