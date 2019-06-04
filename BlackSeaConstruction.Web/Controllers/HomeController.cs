using Microsoft.AspNetCore.Mvc;

namespace BlackSeaConstruction.Web.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            var news = UnitOfWork.News.GetAllNews();
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

        public IActionResult Contact()
        {
            return View();
        }
    }
}
