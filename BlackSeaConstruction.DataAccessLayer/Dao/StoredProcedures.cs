using System.Data;

namespace BlackSeaConstruction.DataAccessLayer.Dao
{
    public class StoredProcedures : DataAccessObject
    {
        public StoredProcedures(IDbConnection connection) : base(connection) { }
    }
}
