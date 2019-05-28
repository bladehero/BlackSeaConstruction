using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BlackSeaConstruction.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Works()
        {
            return View();
        }
    }
}
