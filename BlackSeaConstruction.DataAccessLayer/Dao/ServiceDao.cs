using BlackSeaConstruction.DataAccessLayer.Models;
using System.Collections.Generic;
using System.Data;

namespace BlackSeaConstruction.DataAccessLayer.Dao
{
    public class ServiceDao : BaseDao<Service>
    {
        public ServiceDao(IDbConnection connection) : base("dbo.Services", connection) { }

        public IEnumerable<Service> GetServicesByTypeId(int typeId)
        {
            return Query($"{SelectFromString} where TypeId = {typeId}");
        }
    }
}
