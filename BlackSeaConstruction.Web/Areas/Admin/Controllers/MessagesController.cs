using BlackSeaConstruction.BusinessLogicLayer.ViewModels;
using BlackSeaConstruction.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlackSeaConstruction.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessagesController : AdminController
    {
        public IActionResult Index(int number = 1, int size = 10, bool withDeleted = false)
        {
            var pages = new PageVM(UnitOfWork.Message.MessagesCount(withDeleted), number, size);
            var messages = UnitOfWork.Message.GetMessages(pages.Size, pages.Skip, withDeleted);
            var model = new MessagesVM
            {
                Messages = messages,
                Pages = pages,
                WithDeleted = withDeleted
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteOrRestore(int id)
        {
            return Json(new { result = UnitOfWork.Message.DeleteOrRestoreMessage(id) });
        }
    }
}