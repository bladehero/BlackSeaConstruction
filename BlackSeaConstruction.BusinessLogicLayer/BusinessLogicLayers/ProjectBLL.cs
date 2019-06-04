using BlackSeaConstruction.DataAccessLayer.Dao;
using System.Data;

namespace BlackSeaConstruction.BusinessLogicLayer.BusinessLogicLayers
{
    public class ProjectBLL : BaseBLL
    {
        ProjectDao projects;
        ProjectSectionDao projectSections;
        ProjectSectionImageDao projectSectionImages;

        public ProjectBLL(IDbConnection connection)
        {
            projects = new ProjectDao(connection);
            projectSections = new ProjectSectionDao(connection);
            projectSectionImages = new ProjectSectionImageDao(connection);
        }


    }
}
