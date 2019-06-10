using System;
using System.Linq;
using BlackSeaConstruction.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlackSeaConstruction.Web.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        public const string AuthKey = "__bsco_auth__";

        public bool IsAdmin
        {
            get
            {
                var isAdmin = GetCookie(AuthKey) == GlobalVariables.Authentication.Token;
                if (isAdmin)
                {
                    SetCookie(AuthKey, GlobalVariables.Authentication.GetNewToken());
                }
                return isAdmin;
            }
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var allowAnonymous = ((context.ActionDescriptor as ControllerActionDescriptor)?.MethodInfo.CustomAttributes.Any(x => x.AttributeType == typeof(AllowAnonymousAttribute))).GetValueOrDefault();
            if (allowAnonymous || IsAdmin)
            {
                base.OnActionExecuting(context);
            }
            else
            {
                context.Result = NotFound();
            }
        }

        public string GetCookie(string key)
        {
            return Request.Cookies[key];
        }
        public void SetCookie(string key, string value)
        {
            var options = new CookieOptions()
            {
                Path = "/",
                HttpOnly = false,
                IsEssential = true,
                Expires = DateTime.Now.AddYears(100)
            };
            Response.Cookies.Append(key, value, options);
        }
        public bool Login(string login, string password)
        {
            var result = login == GlobalVariables.Authentication.Login && password == GlobalVariables.Authentication.Password;
            if (result)
            {
                SetCookie(AuthKey, GlobalVariables.Authentication.GetNewToken());
            }
            return result;
        }
    }
}