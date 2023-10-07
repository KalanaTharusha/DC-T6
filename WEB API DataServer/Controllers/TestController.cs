using Microsoft.AspNetCore.Mvc;
using WEB_API_DataServer.Models;

namespace WEB_API_DataServer.Controllers
{
    public class TestController : Controller
    {
        private DataModel _dataModel;
        public IActionResult Index()
        {
            return View();
        }

        public TestController()
        {
            _dataModel = new DataModel();
        }


        [HttpGet]
        public string Ping()
        {
            return "pong";
        }

        [HttpGet]
        public int Entries()
        {
            return _dataModel.GetCount();
        }

    }
}
