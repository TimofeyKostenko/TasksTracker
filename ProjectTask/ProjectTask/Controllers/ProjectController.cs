using Microsoft.AspNetCore.Mvc;
using ProjectTask.Domain.Entity;
using ProjectTask.Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProjectController : ControllerBase
    {
        private readonly IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }


        [HttpGet("{id}")]
        public ActionResult<Project> Get(int id)
        {
            var project = projectService.GetProject(id);
            if (project == null)
            {
                return BadRequest();
            }
            return project;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Project>> GetAll()
        {
            var projects = projectService.GetAll();
            if (projects == null)
            {
                return NotFound();
            }
            return projects.ToList();
        }


        


        [HttpPost]
        public ActionResult<Project> Post([FromBody] Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var newProject = projectService.CreateProject(project);
            return Ok(newProject);

        }


        [HttpPut("{id}")]
        public ActionResult<Project> Put(int id, [FromBody] Project project)
        {
            if (project == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var newProject = projectService.EditProject(id, project);
            return Ok(newProject);
        }


        [HttpDelete("{id}")]
        public ActionResult<Project> Delete(int id)
        {
            var project = projectService.GetProject(id);
            if (project == null)
            {
                return BadRequest();
            }
            projectService.DeleteProject(id);
            var newProject = projectService.GetAll();
            return Ok(newProject);
        }
    }
}
