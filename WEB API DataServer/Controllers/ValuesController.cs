using API_Classes;
using Microsoft.AspNetCore.Mvc;
using WEB_API_DataServer.Models;

namespace WEB_API_DataServer.Controllers
{
    public class ValuesController : Controller
    {
        private DataModel _dataModel;
        public ValuesController()
        {
            _dataModel = new DataModel();
        }

        [HttpGet]
        public int Count()
        {
            return _dataModel.GetCount();
            return 0;
        }

        [HttpGet]
        public IEnumerable<DataIntermed> Entries()
        {
            List<DataIntermed> accounts = _dataModel.GetAll();
            return _dataModel.GetAll();
        }

        [HttpGet]
        public IActionResult Entry()
        {
            DataIntermed result = new DataIntermed();
            result.Pin = 1111;
            result.Balance = 2423435;
            result.AcctNo = 948587468;
            result.FirstName = "Kalana";
            result.LastName = "Tharusha";
            result.Bitmap = "This should be a bitmap";

            return new ObjectResult(result);
        }

    }
}
