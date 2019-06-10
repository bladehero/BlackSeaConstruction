using BlackSeaConstruction.BusinessLogicLayer.ViewModels.Messages;
using BlackSeaConstruction.Web.Extensions;
using BlackSeaConstruction.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;

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
                Projects = UnitOfWork.Projects.GetAllProjectListItems(),
                Project = UnitOfWork.Projects.GetProjectById(id)
            };
            return View(model);
        }

        public IActionResult _Work(int id)
        {
            var model = UnitOfWork.Projects.GetProjectById(id);
            return PartialView(model);
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(MessageVM messageVM)
        {
            var success = true;
            var message = string.Empty;
            var selectors = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    messageVM.Status = Status.P;
                    UnitOfWork.Message.MergeMessage(messageVM);
                }
                catch (Exception)
                {
                    success = false;
                    message = "Internal error. Please, contact support team!";
                }
            }
            else
            {
                success = false;
                message = $"Errors occured:<br /> -{string.Join("<br />- ", ModelState.Values.Where(x => x.ValidationState == ModelValidationState.Invalid).SelectMany(x => x.Errors.Select(e => e.ErrorMessage)))}";
                selectors = string.Join(',', ModelState.AllErrors().Select(x => $"[name={x.Key}]"));
            }

            return Json(new { success, message, selectors });
        }
    }
}
