using System.Data.SqlClient;
using BlackSeaConstruction.BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlackSeaConstruction.Web.Controllers
{
    public class BaseController : Controller
    {
        protected UnitOfWork UnitOfWork { get; }
        private SqlConnection sqlConnection;

        public BaseController()
        {
            sqlConnection = new SqlConnection(Startup.ConnectionString);
            UnitOfWork = new UnitOfWork(sqlConnection);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            sqlConnection.Dispose();
        }
    }
}