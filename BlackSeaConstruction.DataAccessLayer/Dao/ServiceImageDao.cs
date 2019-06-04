using BlackSeaConstruction.DataAccessLayer.Models;
using System.Collections.Generic;
using System.Data;

namespace BlackSeaConstruction.DataAccessLayer.Dao
{
    public class ServiceImageDao : BaseDao<ServiceImage>
    {
        public ServiceImageDao(IDbConnection connection) : base("dbo.ServiceImages", connection) { }

        public IEnumerable<ServiceImage> GetServiceImageByServiceId(int serviceId)
        {
            return Query($"{SelectFromString} where ServiceId = {serviceId}");
        }
    }
}
