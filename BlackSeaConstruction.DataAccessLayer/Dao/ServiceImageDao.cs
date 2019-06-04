using BlackSeaConstruction.DataAccessLayer.Models;
using System.Data;

namespace BlackSeaConstruction.DataAccessLayer.Dao
{
    public class ServiceImageDao : BaseDao<ServiceImage>
    {
        public ServiceImageDao(IDbConnection connection) : base("dbo.ServiceImages", connection) { }
    }
}
