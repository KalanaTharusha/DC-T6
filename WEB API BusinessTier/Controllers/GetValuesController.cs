using API_Classes;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace WEB_API_BusinessTier.Controllers
{
    public class GetValuesController : Controller
    {
        private RestClient restClient;
        public GetValuesController()
        {
            restClient = new RestClient("http://localhost:5080");
        }

        [HttpGet]
        public int Count()
        {
            RestRequest restRequest = new RestRequest("/data/size", Method.Get);
            RestResponse restResponse = restClient.Execute(restRequest);

            return int.Parse(restResponse.Content);
        }

        [HttpGet]
        public IEnumerable<DataIntermed> Entries()
        {
            RestRequest restRequest = new RestRequest("/data/all", Method.Get);
            RestResponse restResponse = restClient.Execute(restRequest);

            IEnumerable<DataIntermed> dataIntermedList = JsonConvert.DeserializeObject<IEnumerable<DataIntermed>>(restResponse.Content);

            return dataIntermedList;
        }

        [HttpGet]
        public IActionResult Detail([FromQuery] int id)
        {
            RestRequest restRequest = new RestRequest("/data/account?id={i}", Method.Get);
            restRequest.AddUrlSegment("i", id);
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
