using System;
using System.Data;

namespace BlackSeaConstruction.DataAccessLayer.Dao
{
    public class DataAccessObject : IDisposable
    {
        protected IDbConnection Connection { get; set; }

        public DataAccessObject(IDbConnection connection) => Connection = connection;

        public void Dispose() => Connection.Dispose();
    }
}
