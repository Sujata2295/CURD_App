using Microsoft.AspNetCore.Mvc;
using State_New.Models;

namespace State_New.Controllers
{
    public class CityController : Controller
    {
        CityDataAccessLayer cityDataAccessLayer=new CityDataAccessLayer();
        public IActionResult Index()
        {
            return View(cityDataAccessLayer.GetAllCity());
        }
    }

}
