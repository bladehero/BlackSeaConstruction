using BlackSeaConstruction.BusinessLogicLayer.ViewModels;
using BlackSeaConstruction.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlackSeaConstruction.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WorksController : AdminController
    {
        public IActionResult Index(int number = 1, int size = 10, bool withDeleted = false)
        {
            var pages = new PageVM(UnitOfWork.Projects.ProjectsCount(withDeleted), number, size);
            var projects = UnitOfWork.Projects.GetProjects(pages.Size, pages.Skip, withDeleted);
            var model = new WorksVM
            {
                Projects = projects,
                Pages = pages,
                WithDeleted = withDeleted
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteOrRestore(int id)
        {
            return Json(new { result = UnitOfWork.Projects.DeleteOrRestoreMessage(id) });
        }
    }
}