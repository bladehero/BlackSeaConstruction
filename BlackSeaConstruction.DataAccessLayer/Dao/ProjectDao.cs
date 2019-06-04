using BlackSeaConstruction.DataAccessLayer.Models;
using System.Data;

namespace BlackSeaConstruction.DataAccessLayer.Dao
{
    public class ProjectDao : BaseDao<Project>
    {
        public ProjectDao(IDbConnection connection) : base("dbo.Projects", connection) { }
    }
}
