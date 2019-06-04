using BlackSeaConstruction.DataAccessLayer.Models;
using System.Data;

namespace BlackSeaConstruction.DataAccessLayer.Dao
{
    public class ServiceTypeDao : BaseDao<ServiceType>
    {
        public ServiceTypeDao(IDbConnection connection) : base("dbo.ServiceTypes", connection) { }
    }
}
