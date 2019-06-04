using AutoMapper;
using BlackSeaConstruction.BusinessLogicLayer.ViewModels.Projects;
using BlackSeaConstruction.DataAccessLayer.Dao;
using BlackSeaConstruction.DataAccessLayer.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BlackSeaConstruction.BusinessLogicLayer.BusinessLogicLayers
{
    public class ProjectBLL : BaseBLL
    {
        ProjectDao _projects;
        ProjectSectionDao _projectSections;
        ProjectSectionImageDao _projectSectionImages;

        public ProjectBLL(IDbConnection connection)
        {
            _projects = new ProjectDao(connection);
            _projectSections = new ProjectSectionDao(connection);
            _projectSectionImages = new ProjectSectionImageDao(connection);

            Mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProjectSection, ProjectSectionVM>().AfterMap((m, vm) =>
                {
                    vm.Images = _projectSectionImages.GetSectionImagesBySectionId(m.Id).Select(z => z.Image);
                    vm.ProjectName = _projects.FindById(m.ProjectId)?.ProjectName;
                });
                cfg.CreateMap<ProjectSectionVM, ProjectSection>();
                cfg.CreateMap<Project, ProjectVM>().AfterMap((m, vm) =>
                {
                    vm.ProjectSections = _projectSections.GetSectionsByProjectId(m.Id).Select(x => new ProjectSectionVM
                    {
                        Id = x.Id,
                        ProjectName = m.ProjectName,
                        SectionName = x.SectionName,
                        Images = _projectSectionImages.GetSectionImagesBySectionId(m.Id).Select(s => s.Image)
                    }).ToList();
                });
                cfg.CreateMap<ProjectVM, Project>();
            }).CreateMapper();
        }

        public ProjectVM GetProjectById(int? id)
        {
            if (!id.HasValue)
            {
                return null;
            }

            var project = _projects.FindById(id.Value);
            var projectVM = Map<Project, ProjectVM>(project);
            return projectVM;
        }

        public IEnumerable<ProjectVM> GetAllProjects()
        {
            var projects = _projects.FindAll();
            var projectVMs = Map<IEnumerable<Project>, IEnumerable<ProjectVM>>(projects);
            return projectVMs;
        }
    }
}
