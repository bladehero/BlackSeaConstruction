using BlackSeaConstruction.DataAccessLayer.Models;
using System.Collections.Generic;
using System.Data;

namespace BlackSeaConstruction.DataAccessLayer.Dao
{
    public class NewsDao : BaseDao<News>
    {
        public NewsDao(IDbConnection connection) : base("dbo.News", connection) { }

        public IEnumerable<News> GetLastNews(int count) => Query($"select top {count} * from {TableName} where IsDeleted = 0 order by DateCreated desc");
    }
}
