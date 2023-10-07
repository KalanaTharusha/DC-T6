using API_Classes;
using Microsoft.AspNetCore.Mvc;
using WEB_API_BusinessTier.Models;

namespace WEB_API_BusinessTier.Controllers
{
    public class GetValuesController : Controller
    {
        private DataModel _dataModel;
        public GetValuesController()
        {
            _dataModel = new DataModel();
        }

        [HttpGet]
        public int Count()
        {
            return _dataModel.GetNumEntries();
        }

        [HttpGet]
        public IEnumerable<DataIntermed> Entries()
        {
            List<DataIntermed> accounts = _dataModel.GetAll();
            return _dataModel.GetAll();
        }

        [HttpGet]
        public IActionResult Detail(int id)
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

    }
}
