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
        }

        [HttpGet]
        public IEnumerable<DataIntermed> Entries()
        {
            List<DataIntermed> accounts = _dataModel.GetAll();
            return _dataModel.GetAll();
        }

    }
}
