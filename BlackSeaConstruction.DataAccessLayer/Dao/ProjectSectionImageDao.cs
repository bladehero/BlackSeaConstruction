using BlackSeaConstruction.DataAccessLayer.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;

namespace BlackSeaConstruction.DataAccessLayer.Dao
{
    public class ProjectSectionImageDao : BaseDao<ProjectSectionImage>
    {
        public ProjectSectionImageDao(IDbConnection connection) : base("dbo.ProjectSectionImages", connection) { }

        public IEnumerable<string> GetSectionImagesBySectionId(int sectionId)
        {
            var result = Connection.Query<string>($"select [Image] from {TableName} where SectionId = {sectionId}");
            return result;
        }
    }
}
