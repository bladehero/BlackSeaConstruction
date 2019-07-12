using BlackSeaConstruction.BusinessLogicLayer.ViewModels;
using BlackSeaConstruction.BusinessLogicLayer.ViewModels.Projects;
using BlackSeaConstruction.Web.Areas.Admin.Models;
using BlackSeaConstruction.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.IO;
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

        [HttpPost]
        public IActionResult MergeWork(WorkAddOrUpdateVM model)
        {
            var result = true;
            var message = string.Empty;

            try
            {
                var project = new ProjectVM
                {
                    Id = model.Id.GetValueOrDefault(),
                    ProjectName = model.Name,
                    Description = model.Description,
                    Latitude = (decimal?)model.Latitude,
                    Longtitude = (decimal?)model.Longtitude
                };

                var projectCreated = UnitOfWork.Projects.MergeProject(project);
                if (projectCreated)
                {
                    if (model.Sections?.Count() > 0)
                    {
                        foreach (var section in model.Sections)
                        {
                            var _section = new ProjectSectionVM
                            {
                                Id = section.Id.GetValueOrDefault(),
                                Description = section.Description,
                                SectionName = section.Name,
                                ProjectId = project.Id
                            };
                            UnitOfWork.Projects.MergeProjectSection(_section);
                            if (section.Images?.Count() > 0)
                            {
                                foreach (var image in section.Images)
                                {
                                    if (image.Updated)
                                    {
                                        UnitOfWork.Projects.MergeProjectSectionImage(new ProjectSectionImageVM
                                        {
                                            Id = image.Id.GetValueOrDefault(),
                                            Image = image.FileName,
                                            SectionId = _section.Id
                                        });
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                result = false;
                message = ex.ToString();
            }

            return Json(new { result, message });
        }

        public IActionResult UploadWorkImages()
        {
            var result = true;
            var message = string.Empty;

            try
            {
                var root = ImageExtensions.ResourceDirectory;
                foreach (var file in Request.Form.Files)
                {
                    if (file.Length > 0)
                    {
                        var path = Path.Combine(root, ImageExtensions.ImageFolder, ImageExtensions.WorksFolder, file.Name);
                        using (var fs = new FileStream(path, FileMode.Create))
                        {
                            file.CopyTo(fs);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                result = false;
                message = ex.ToString();
            }

            return Json(new { result, message });
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