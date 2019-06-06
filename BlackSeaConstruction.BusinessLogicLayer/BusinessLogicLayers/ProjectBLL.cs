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
                    vm.Images = _projectSectionImages.GetSectionImagesBySectionId(m.Id);
                    vm.ProjectName = _projects.FindById(m.ProjectId)?.ProjectName;
                });
                cfg.CreateMap<ProjectSectionVM, ProjectSection>();
                cfg.CreateMap<Project, ProjectVM>();
                cfg.CreateMap<ProjectVM, Project>();
            }).CreateMapper();
        }

        public ProjectVM GetProjectById(int? id)
        {
            var project = id.HasValue ? _projects.FindById(id.Value) : _projects.FirstOrDefault();
            var projectVM = Map<Project, ProjectVM>(project);
            projectVM.ProjectSections = _projectSections.GetSectionsByProjectId(project.Id).Select(x => new ProjectSectionVM
            {
                Id = x.Id,
                ProjectName = project.ProjectName,
                SectionName = x.SectionName,
                Description = x.Description,
                Images = _projectSectionImages.GetSectionImagesBySectionId(x.Id)
            }).ToList();
            return projectVM;
        }

        public IEnumerable<ProjectVM> GetAllProjects()
        {
            var projects = _projects.FindAll();
            var projectVMs = Map<IEnumerable<Project>, IEnumerable<ProjectVM>>(projects);
            return projectVMs;
        }

        public IEnumerable<ProjectListItemVM> GetAllProjectListItems()
        {
            var projects = _projects.FindAll();
            var projectVMs = projects.Select(x => new ProjectListItemVM
            {
                Id = x.Id,
                ProjectName = x.ProjectName
            });
            return projectVMs;
        }
    }
}
