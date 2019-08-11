using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Metrics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DemoAppInsights.Controllers
{
    public class LogsController : Controller
    {
        private TelemetryClient _telemetry;
        private ILogger<LogsController> _log;

        public LogsController(TelemetryClient telemetry, ILogger<LogsController> log)
        {
            _telemetry = telemetry;
            _log = log;
        }

        public IActionResult Index()
        {
            _telemetry.TrackEvent("Hello LogsController.Index!");

            //_log.LogTrace("Trace depuis ILogger");
            //_log.LogWarning("Warning depuis ILogger");
            //_log.Log(LogLevel.Critical, "Critical log depuis ILogger");

            return View();
        }

        public IActionResult CustomMetric()
        {
            _telemetry.GetMetric("MyMetric").TrackValue(555);

            return View("Index");
        }
    }
}