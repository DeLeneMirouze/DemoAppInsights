using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApiInsights.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestInsightsController : ControllerBase
    {
        // GET api/TestInsights
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "ApiInsights a été invoquée.";
        }
    }
}
