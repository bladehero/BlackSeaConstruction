using BlackSeaConstruction.DataAccessLayer.Models;
using System.Data;

namespace BlackSeaConstruction.DataAccessLayer.Dao
{
    public class ServiceDao : BaseDao<Service>
    {
        public ServiceDao(IDbConnection connection) : base("dbo.Services", connection) { }
    }
}
