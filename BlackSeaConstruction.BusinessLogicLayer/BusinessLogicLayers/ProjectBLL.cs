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
                    vm.Images = _projectSectionImages.GetSectionImagesBySectionId(m.Id).Select(x => new ProjectSectionImageVM { Id = x.Id, Image = x.Image });
                    vm.ProjectName = _projects.FindById(m.ProjectId)?.ProjectName;
                });
                cfg.CreateMap<ProjectSectionVM, ProjectSection>();
                cfg.CreateMap<Project, ProjectVM>();
                cfg.CreateMap<ProjectVM, Project>();
            }).CreateMapper();
        }

        public int ProjectsCount(bool withDeleted = true) => _projects.Count(withDeleted);

        public IEnumerable<ProjectVM> GetProjects(int count = 10, int skip = 0, bool withDeleted = true)
        {
            var projects = _projects.Take(count, skip, withDeleted);
            var projectVMs = Map<IEnumerable<Project>, IEnumerable<ProjectVM>>(projects);
            return projectVMs;
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
                Images = _projectSectionImages.GetSectionImagesBySectionId(x.Id).Select(i => new ProjectSectionImageVM { Id = i.Id, Image = i.Image } )
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
                ProjectName = x.ProjectName,
                Latitude = x.Latitude,
                Longtitude = x.Longtitude
            });
            return projectVMs;
        }

        public bool DeleteProject(int id) => _projects.Delete(id);
        public bool RestoreProject(int id) => _projects.Restore(id);
        public bool DeleteOrRestoreProject(int id) => _projects.FindById(id).IsDeleted ? _projects.Restore(id) : _projects.Delete(id);

        public bool DeleteSectionImage(int id) => _projectSectionImages.Delete(id);
    }
}
