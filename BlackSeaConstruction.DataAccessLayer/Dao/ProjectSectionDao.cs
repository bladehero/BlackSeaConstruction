using BlackSeaConstruction.DataAccessLayer.Models;
using System.Data;

namespace BlackSeaConstruction.DataAccessLayer.Dao
{
    public class ProjectSectionDao : BaseDao<ProjectSection>
    {
        public ProjectSectionDao(IDbConnection connection) : base("dbo.ProjectSections", connection) { }
    }
}
