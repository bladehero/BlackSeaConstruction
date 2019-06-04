using BlackSeaConstruction.DataAccessLayer.Models;
using System.Data;

namespace BlackSeaConstruction.DataAccessLayer.Dao
{
    public class MessageDao : BaseDao<Message>
    {
        public MessageDao(IDbConnection connection) : base("dbo.Messages", connection) { }
    }
}
