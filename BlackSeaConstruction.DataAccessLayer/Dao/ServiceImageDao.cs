using BlackSeaConstruction.DataAccessLayer.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;

namespace BlackSeaConstruction.DataAccessLayer.Dao
{
    public class ServiceImageDao : BaseDao<ServiceImage>
    {
        public ServiceImageDao(IDbConnection connection) : base("dbo.ServiceImages", connection) { }

        public IEnumerable<string> GetServiceImageByServiceId(int serviceId)
        {
            return Connection.Query<string>($"select [Image] from {TableName}  where ServiceId = {serviceId}");
        }
    }
}
