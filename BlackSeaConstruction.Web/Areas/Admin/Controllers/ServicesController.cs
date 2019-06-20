using System;
using System.Collections.Generic;
using System.IO;
using System.Transactions;
using BlackSeaConstruction.BusinessLogicLayer.ViewModels;
using BlackSeaConstruction.BusinessLogicLayer.ViewModels.Services;
using BlackSeaConstruction.Web.Areas.Admin.Models;
using BlackSeaConstruction.Web.Extensions;
using Microsoft.AspNetCore.Http;
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
        public IActionResult MergeService(MergeServiceVM mergeService)
        {
            var result = true;
            var message = string.Empty;

            try
            {
                using (var scope = new TransactionScope(TransactionScopeOption.Suppress))
                {
                    var service = new ServiceVM
                    {
                        Id = mergeService.Id.GetValueOrDefault(),
                        Description = mergeService.Description,
                        ServiceName = mergeService.ServiceName,
                        TypeId = mergeService.TypeId
                    };

                    result = UnitOfWork.Services.MergeService(service);

                    if (result)
                    {
                        foreach (var image in mergeService.Images)
                        {
                            if (image.Updated.GetValueOrDefault() && !string.IsNullOrWhiteSpace(image.Image))
                            {
                                var imageVM = new ServiceImageVM
                                {
                                    Id = image.Id.GetValueOrDefault(),
                                    Image = image.Image,
                                    ServiceId = service.Id
                                };
                                result = UnitOfWork.Services.MergeServiceImage(imageVM);
                                if (!result)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    if (result)
                    {
                        scope.Complete();
                    }
                }
            }
            catch (System.Exception ex)
            {
                result = false;
                message = UnknownError;
            }

            return Json(new { result, message });
        }

        [HttpPost]
        public IActionResult UploadImages()
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
                        var path = Path.Combine(root, ImageExtensions.ImageFolder, ImageExtensions.ServicesFolder, file.Name);
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
                message = UnknownError;
            }

            return Json(new { result, message });
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
            var service = UnitOfWork.Services.GetServiceById(id);
            foreach (var image in service.Images)
            {
                image.Image = $"../{ImageExtensions.ServicesImage(image.Image)}";
            }

            return Json(service);
        }

        [HttpDelete]
        public IActionResult DeleteServiceImage(int id)
        {
            return Json(new { result = UnitOfWork.Services.DeleteServiceImage(id) });
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