using BlackSeaConstruction.DataAccessLayer.Dao;
using System.Data;

namespace BlackSeaConstruction.BusinessLogicLayer.BusinessLogicLayers
{
    public class MessageBLL : BaseBLL
    {
        MessageDao messages;

        public MessageBLL(IDbConnection connection)
        {
            messages = new MessageDao(connection);
        }
    }
}
