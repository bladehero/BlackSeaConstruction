using BlackSeaConstruction.BusinessLogicLayer.ViewModels;
using BlackSeaConstruction.BusinessLogicLayer.ViewModels.Projects;
using BlackSeaConstruction.Web.Areas.Admin.Models;
using BlackSeaConstruction.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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

        public IActionResult GetWorkById(int id)
        {
            var work = UnitOfWork.Projects.GetProjectById(id);
            foreach (var section in work.ProjectSections)
            {
                section.Images = section.Images.Select(x => new ProjectSectionImageVM { Id = x.Id, Image = "../" + ImageExtensions.WorksImage(x.Image) });
            }
            return Json(new { work });
        }

        [HttpDelete]
        public IActionResult DeleteSectionImage(int id)
        {
            return Json(new { result = UnitOfWork.Projects.DeleteSectionImage(id) });
        }

        [HttpPost]
        public IActionResult DeleteOrRestore(int id)
        {
            return Json(new { result = UnitOfWork.Projects.DeleteOrRestoreProject(id) });
        }
    }
}