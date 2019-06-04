using BlackSeaConstruction.BusinessLogicLayer.BusinessLogicLayers;
using System.Data;

namespace BlackSeaConstruction.BusinessLogicLayer
{
    public class UnitOfWork
    {
        public NewsBLL News { get; set; }

        public UnitOfWork(IDbConnection connection)
        {
            News = new NewsBLL(connection);
        }
    }
}
