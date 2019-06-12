using BlackSeaConstruction.BusinessLogicLayer.ViewModels;
using BlackSeaConstruction.BusinessLogicLayer.ViewModels.Messages;
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

        public IActionResult GetMessageById(int id)
        {
            return Json(UnitOfWork.Message.GetMessageById(id));
        }

        [HttpPost]
        public IActionResult UpdateMessageStatus(int id, int status)
        {
            var result = true;
            try
            {
                var message = UnitOfWork.Message.GetMessageById(id);
                message.Status = (Status)status;
                result = UnitOfWork.Message.MergeMessage(message);
            }
            catch (System.Exception)
            {
                result = false;
            }
            return Json(new { result });
        }

        [HttpPost]
        public IActionResult DeleteOrRestore(int id)
        {
            return Json(new { result = UnitOfWork.Message.DeleteOrRestoreMessage(id) });
        }
    }
}