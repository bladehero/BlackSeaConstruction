using BlackSeaConstruction.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BlackSeaConstruction.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MainController : AdminController
    {
        private const string TokenToBlockOrUnblock = "1a2b3c";
        private IConfiguration _configuration;

        public MainController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginVM model)
        {
            return Json(new { result = Login(model.Login, model.Password) });
        }

        [HttpGet]
        public IActionResult Block(string token)
        {
            bool result;
            try
            {
                if (_configuration != null && token == TokenToBlockOrUnblock)
                {
                    _configuration["IsBlocked"] = "true";
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (System.Exception)
            {
                result = false;
            }
            return Json(result);
        }

        [HttpGet]
        public IActionResult Unblock(string token)
        {
            bool result;
            try
            {
                if (_configuration != null && token == TokenToBlockOrUnblock)
                {
                    _configuration["IsBlocked"] = "false";
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (System.Exception)
            {
                result = false;
            }
            return Json(result);
        }
    }
}