using System;
using BlackSeaConstruction.BusinessLogicLayer.ViewModels;
using BlackSeaConstruction.BusinessLogicLayer.ViewModels.Services;
using BlackSeaConstruction.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlackSeaConstruction.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServicesController : AdminController
    {
        public IActionResult Index(int number = 1, int size = 10, bool withDeleted = false)
        {
            var pages = new PageVM(UnitOfWork.Services.ServicesCount(withDeleted), number, size);
            var services = UnitOfWork.Services.GetServices(pages.Size, pages.Skip, withDeleted);
            var serviceTypes = UnitOfWork.Services.GetAllServiceTypes(true);
            var model = new ServiceIndexVM
            {
                Services = services,
                ServiceTypes = serviceTypes,
                Pages = pages,
                WithDeleted = withDeleted
            };
            return View(model);
        }

        public IActionResult GetServiceTypeById(int id)
        {
            return Json(UnitOfWork.Services.GetServiceTypeById(id));
        }

        [HttpPost]
        public IActionResult MergeServiceType(ServiceTypeVM serviceType)
        {
            var result = true;
            var message = string.Empty;

            try
            {
                result = UnitOfWork.Services.MergeServiceType(serviceType);
            }
            catch (Exception ex)
            {
                result = false;
                message = UnknownError;
            }

            return Json(new { result, message });
        }

        public IActionResult GetServiceById(int id)
        {
            return Json(UnitOfWork.Services.GetServiceById(id));
        }

        [HttpPost]
        public IActionResult DeleteOrRestore(int id)
        {
            return Json(new { result = UnitOfWork.Services.DeleteOrRestoreService(id) });
        }

        [HttpPost]
        public IActionResult DeleteOrRestoreServiceType(int id)
        {
            return Json(new { result = UnitOfWork.Services.DeleteOrRestoreServiceType(id) });
        }
    }
}