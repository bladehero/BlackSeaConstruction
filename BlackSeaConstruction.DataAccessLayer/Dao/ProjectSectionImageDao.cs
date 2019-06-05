using BlackSeaConstruction.DataAccessLayer.Models;
using System.Collections.Generic;
using System.Data;

namespace BlackSeaConstruction.DataAccessLayer.Dao
{
    public class ProjectSectionImageDao : BaseDao<ProjectSectionImage>
    {
        public ProjectSectionImageDao(IDbConnection connection) : base("dbo.ProjectSectionImages", connection) { }

        public IEnumerable<ProjectSectionImage> GetSectionImagesBySectionId(int sectionId)
        {
            return Query($"{SelectFromString} where SectionId = {sectionId}");
        }
    }
}
