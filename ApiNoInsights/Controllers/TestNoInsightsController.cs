using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApiNoInsights.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestNoInsightsController : ControllerBase
    {
        // GET api/ApiNoInsights
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "ApiNoInsights a été invoquée.";
        }
        
    }
}
