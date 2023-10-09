using API_Classes;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace WEB_API_BusinessTier.Controllers
{
    public class SearchController : Controller
    {
        private RestClient restClient;
        public SearchController() 
        {
            restClient = new RestClient("http://localhost:5080");
        }


        [HttpPost]
        public IActionResult Search([FromBody] SearchData search)
        {
            RestRequest restRequest = new RestRequest("data/search", Method.Get);
            restRequest.AddJsonBody(search);
            RestResponse restResponse = restClient.Execute(restRequest);

            DataIntermed dataIntermed = JsonConvert.DeserializeObject<DataIntermed>(restResponse.Content);

            if (dataIntermed == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(dataIntermed) { StatusCode = 200 };
            }
        }
    }
}
