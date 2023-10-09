using API_Classes;
using Microsoft.AspNetCore.Mvc;
using WEB_API_DataServer.Models;

namespace WEB_API_DataServer.Controllers
{
    public class DataController : Controller
    {
        private DataModel _dataModel;

        public DataController()
        {
            _dataModel = new DataModel();
        }

        [HttpGet]
        public int Size()
        {
            return _dataModel.GetNumEntries();
        }

        [HttpGet]
        public IEnumerable<DataIntermed> All()
        {
            List<DataIntermed> accounts = _dataModel.GetAll();
            return _dataModel.GetAll();
        }

        [HttpGet]
        public IActionResult Account([FromQuery] int id)
        {
            DataIntermed dataIntermed = _dataModel.GetValuesForEntry(id);
            if (dataIntermed == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(dataIntermed) { StatusCode = 200 };
            }

        }

        [HttpGet]
        public IActionResult Search([FromBody] SearchData search)
        {
            DataIntermed dataIntermed = _dataModel.Search(search.SearchStr);
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
