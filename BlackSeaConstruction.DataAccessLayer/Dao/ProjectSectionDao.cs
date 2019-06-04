using BlackSeaConstruction.DataAccessLayer.Models;
using System.Collections.Generic;
using System.Data;

namespace BlackSeaConstruction.DataAccessLayer.Dao
{
    public class ProjectSectionDao : BaseDao<ProjectSection>
    {
        public ProjectSectionDao(IDbConnection connection) : base("dbo.ProjectSections", connection) { }

        public IEnumerable<ProjectSection> GetSectionsByProjectId(int projectId)
        {
            return Query($"{SelectFromString} where ProjectId = {projectId}");
        }
    }
}
