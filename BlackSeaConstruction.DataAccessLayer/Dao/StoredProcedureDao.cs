using System.Data;

namespace BlackSeaConstruction.DataAccessLayer.Dao
{
    public class StoredProcedureDao : DataAccessObject
    {
        public StoredProcedureDao(IDbConnection connection) : base(connection) { }
    }
}
