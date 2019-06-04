using BlackSeaConstruction.DataAccessLayer.Models;
using System.Data;

namespace BlackSeaConstruction.DataAccessLayer.Dao
{
    public class NewsDao : BaseDao<News>
    {
        public NewsDao(IDbConnection connection) : base("dbo.News", connection) { }
    }
}
