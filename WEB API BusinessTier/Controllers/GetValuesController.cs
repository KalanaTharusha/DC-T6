using Microsoft.AspNetCore.Mvc;

namespace WEB_API_BusinessTier.Controllers
{
    public class GetValuesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
