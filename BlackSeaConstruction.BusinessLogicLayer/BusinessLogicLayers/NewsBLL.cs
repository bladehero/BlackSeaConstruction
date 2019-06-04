using BlackSeaConstruction.DataAccessLayer.Dao;
using System.Data;

namespace BlackSeaConstruction.BusinessLogicLayer.BusinessLogicLayers
{
    public class NewsBLL
    {
        NewsDao news;

        public NewsBLL(IDbConnection connection)
        {
            news = new NewsDao(connection);
        }
    }
}
