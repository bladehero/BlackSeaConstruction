using BlackSeaConstruction.BusinessLogicLayer.ViewModels;
using BlackSeaConstruction.BusinessLogicLayer.ViewModels.News;
using BlackSeaConstruction.Web.Areas.Admin.Models;
using BlackSeaConstruction.Web.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BlackSeaConstruction.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsController : AdminController
    {
        public IActionResult Index(int number = 1, int size = 10, bool withDeleted = false)
        {
            var works = UnitOfWork.Projects.GetAllProjects().ToList();
            var services = UnitOfWork.Services.GetAllServices().ToList();

            var worksDictionary = new Dictionary<string, string>(works.Count);
            var servicesDictionary = new Dictionary<string, string>(services.Count);

            works.ForEach(x => worksDictionary.Add(Url.Action("Works", "Home", new { area = (string)null, id = x.Id }), x.ProjectName));
            services.ForEach(x => servicesDictionary.Add(Url.Action("Services", "Home", new { area = (string)null, id = x.Id }), $"{x.ServiceName}, {x.ServiceType}"));

            var pages = new PageVM(UnitOfWork.News.NewsCount(withDeleted), number, size);
            var news = UnitOfWork.News.GetNews(pages.Size, pages.Skip, withDeleted);

            var model = new NewsIndexVM
            {
                News = news,
                Pages = pages,
                WithDeleted = withDeleted,
                ServicesDictionary = servicesDictionary,
                WorksDictionary = worksDictionary
            };
            return View(model);
        }

        public IActionResult GetNewsById(int id)
        {
            var news = UnitOfWork.News.GetNewsById(id);
            news.Image = $"../{ImageExtensions.NewsImage(news.Image)}";
            return Json(news);
        }

        [HttpPost]
        public IActionResult MergeNews(MergeNewsVM mergeNews)
        {
            var result = true;
            var message = string.Empty;

            try
            {
                var news = new NewsVM
                {
                    Id = mergeNews.Id.GetValueOrDefault(),
                    DatePublication = DateTime.Now,
                    Description = mergeNews.Description,
                    Header = mergeNews.Header,
                    Image = mergeNews.Image,
                    Link = mergeNews.Url
                };

                if (!mergeNews.Updated.GetValueOrDefault() && mergeNews.Id.HasValue)
                {
                    var _news = UnitOfWork.News.GetNewsById(mergeNews.Id.Value);
                    news.Image = _news.Image;
                }

                result = UnitOfWork.News.MergeNews(news);
            }
            catch (System.Exception ex)
            {
                result = false;
                message = UnknownError;
            }

            return Json(new { result, message });
        }

        [HttpPost]
        public IActionResult UploadImage(IFormFile file)
        {
            var result = true;
            var message = string.Empty;

            try
            {
                var root = ImageExtensions.ResourceDirectory;
                if (file.Length > 0)
                {
                    var path = Path.Combine(root, ImageExtensions.ImageFolder, ImageExtensions.NewsFolder, file.FileName);
                    using (var fs = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(fs);
                    }
                }
                else
                {
                    message = "File is empty or doesn't exist!";
                    result = false;
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
        public IActionResult DeleteOrRestore(int id)
        {
            return Json(new { result = UnitOfWork.News.DeleteOrRestoreNews(id) });
        }
    }
}