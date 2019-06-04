using BlackSeaConstruction.BusinessLogicLayer.BusinessLogicLayers;
using System.Data;

namespace BlackSeaConstruction.BusinessLogicLayer
{
    public class UnitOfWork
    {
        public NewsBLL News { get; set; }
        public ServiceBLL Services { get; set; }
        public ProjectBLL Projects { get; set; }


        public UnitOfWork(IDbConnection connection)
        {
            News = new NewsBLL(connection);
            Services = new ServiceBLL(connection);
            Projects = new ProjectBLL(connection);
        }
    }
}
