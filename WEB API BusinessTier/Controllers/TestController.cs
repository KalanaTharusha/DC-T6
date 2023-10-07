using Microsoft.AspNetCore.Mvc;

namespace WEB_API_BusinessTier.Controllers
{
    public class TestController : Controller
    {
        [HttpGet]
        public string Ping()
        {
            return "pong";
        }
    }
}
