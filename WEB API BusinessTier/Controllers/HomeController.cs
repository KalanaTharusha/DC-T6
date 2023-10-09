using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Diagnostics;
using WEB_API_BusinessTier.Models;

namespace WEB_API_BusinessTier.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public int Index()
        {
            RestClient restClient = new RestClient("http://localhost:5080");
            RestRequest restRequest = new RestRequest("/data/size", Method.Get);
            RestResponse restResponse = restClient.Execute(restRequest);

            return int.Parse(restResponse.Content);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}