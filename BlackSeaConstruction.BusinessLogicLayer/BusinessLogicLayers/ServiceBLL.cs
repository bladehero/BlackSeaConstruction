using BlackSeaConstruction.DataAccessLayer.Dao;
using System.Data;

namespace BlackSeaConstruction.BusinessLogicLayer.BusinessLogicLayers
{
    public class ServiceBLL
    {
        ServiceDao services;
        ServiceImageDao serviceImages;
        ServiceTypeDao serviceTypes;

        public ServiceBLL(IDbConnection connection)
        {
            services = new ServiceDao(connection);
            serviceImages = new ServiceImageDao(connection);
            serviceTypes = new ServiceTypeDao(connection);
        }
    }
}
