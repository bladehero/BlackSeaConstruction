using Microsoft.AspNetCore.Mvc;

namespace BlackSeaConstruction.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}