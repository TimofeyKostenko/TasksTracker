using ProjectTask.DAL.Interface;
using ProjectTask.Domain.Entity;
using ProjectTask.Service.Exceprtion;
using ProjectTask.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTask.Service.Implementation
{
    public class ProjectService : IProjectService
    {
        //adding reposiroties for Projects
        private readonly IBaseRepository<Project> projectRepo;

        public ProjectService(IBaseRepository<Project> projectRepo)
        {
            this.projectRepo = projectRepo;
        }
        public async Task<Project> CreateProject(Project project)
        {
            var newProject = new Project()
            {
                ProjectName = project.ProjectName,
                StartDate = project.StartDate,
                CompletionDate = project.CompletionDate,
                Status = project.Status,
                Priority = project.Priority
            };
            await projectRepo.Create(newProject);
            return newProject;
        }

        public async Task<bool> DeleteProject(int id)
        {
            var project = projectRepo.Get(id);
            if(project == null)
            {
                throw new ValidationException("There is no object with this id", "");
            }
            await projectRepo.Delete(project);
            return true;
        }

        public async Task<Project> EditProject(int id, Project project)
        {
            var changedProject = projectRepo.Get(id);
            if (changedProject == null)
            {
                throw new ValidationException("There is no object with this id", "");
            };

            changedProject.ProjectName = project.ProjectName;
            changedProject.StartDate = project.StartDate;
            changedProject.CompletionDate = project.CompletionDate;
            changedProject.Status = project.Status;
            changedProject.Priority = project.Priority;

            await projectRepo.Update(changedProject);
            return changedProject;
        }

        public IQueryable<Project> GetAll()
        {
           var projects = projectRepo.GetAll();
           if(projects == null)
            {
                throw new ValidationException("Table is empty", "");
            }
            return projects;

        }

        public Project GetProject(int id)
        {
            var project = projectRepo.Get(id);
            if (project == null)
            {
                throw new ValidationException("There is no object with this id", "");
            }
            return project;
        }
    }
}
