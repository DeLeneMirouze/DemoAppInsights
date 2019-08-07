using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;

namespace DemoAppInsights.Controllers
{
    public class ErrorController : Controller
    {
        private TelemetryClient _telemetry;

        public ErrorController(TelemetryClient telemetry)
        {
            _telemetry = telemetry;
        }

        public IActionResult Error404()
        {
            _telemetry.TrackEvent("Page Error404");

            Response.StatusCode = 404;
            return View("Error404");
        }
    }
}