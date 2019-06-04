using BlackSeaConstruction.DataAccessLayer.Models;
using System.Data;

namespace BlackSeaConstruction.DataAccessLayer.Dao
{
    public class ProjectSectionImageDao : BaseDao<ProjectSectionImage>
    {
        public ProjectSectionImageDao(IDbConnection connection) : base("dbo.ProjectSectionImages", connection) { }
    }
}
