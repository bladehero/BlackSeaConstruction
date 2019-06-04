using BlackSeaConstruction.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlackSeaConstruction.Web.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            var model = new IndexVM
            {
                News = UnitOfWork.News.GetNews()
            };
            return View(model);
        }

        public IActionResult Services(int? id = null)
        {
            var model = new ServicesVM
            {
                Services = UnitOfWork.Services.GetAllServiceTypes(),
                Service = UnitOfWork.Services.GetServiceById(id)
            };
            return View(model);
        }

        public IActionResult Works(int? id = null)
        {
            var model = new WorksVM
            {
                Projects = UnitOfWork.Projects.GetAllProjects(),
                Project = UnitOfWork.Projects.GetProjectById(id)
            };
            return View(model);
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
