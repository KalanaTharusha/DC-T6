using Microsoft.AspNetCore.Mvc;
using WEB_API_DataServer.Models;

namespace WEB_API_DataServer.Controllers
{
    public class GetValuesController : Controller
    {
        private DataModel _dataModel;
        public GetValuesController()
        {
            _dataModel = new DataModel();
        }
    }
}
