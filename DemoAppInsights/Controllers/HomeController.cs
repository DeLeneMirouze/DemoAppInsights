using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DemoAppInsights.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Options;

namespace DemoAppInsights.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppSettings _mySettings;

        public HomeController(IOptions<AppSettings> settings)
        {
            _mySettings = settings.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Simulation d'une erreur
        /// </summary>
        /// <returns></returns>
        public IActionResult ErrorNotFound()
        {
            return NotFound();
        }

        /// <summary>
        /// Ecriture dans une queue
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Queue()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_mySettings.Queue);
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference("servicequeue");
            await queue.CreateIfNotExistsAsync();
            CloudQueueMessage message = new CloudQueueMessage("Hello, World");
            await queue.AddMessageAsync(message);

            ViewData["Message"] = "Un message a été ajouté à la queue";
            return View();
        }

        /// <summary>
        /// Appel d'une api monitorée par Application Insights
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> WebApi()
        {
            string reponse = null;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(_mySettings.apiInsightsUrl);
            if (response.IsSuccessStatusCode)
            {
                reponse = await response.Content.ReadAsStringAsync();
            }

            ViewData["Message"] = $"Message: {reponse}";

            return View();
        }

        /// <summary>
        /// Appel d'une api NON monitorée par Application Insights
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> WebApi2()
        {
            string reponse = null;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(_mySettings.apiNoInsightsUrl);
            if (response.IsSuccessStatusCode)
            {
                reponse = await response.Content.ReadAsStringAsync();
            }

            ViewData["Message"] = $"Message: {reponse}";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
