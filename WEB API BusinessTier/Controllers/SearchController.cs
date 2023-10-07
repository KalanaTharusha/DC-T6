using API_Classes;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WEB_API_BusinessTier.Models;

namespace WEB_API_BusinessTier.Controllers
{
    public class SearchController : Controller
    {
        private DataModel _dataModel;
        public SearchController() 
        {
            _dataModel = new DataModel();
        }


        [HttpPost]
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
