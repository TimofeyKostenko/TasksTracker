using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjectTask.Domain.Entity;
using ProjectTask.Service.Implementation;
using ProjectTask.Service.Interfaces;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionsController : ControllerBase
    {
        private readonly IMissionService missionService;

        public MissionsController(IMissionService missionService)
        {
            this.missionService = missionService;
        }
        
     
        [HttpGet("{id}")]
        public ActionResult<Mission> Get(int id)
        {
            var mission = missionService.GetMission(id);
            if (mission == null)
            {
                return BadRequest();
            }
            return mission;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Mission>> GetAll()
        {
            var missions = missionService.GetAll();
            if (missions == null)
            {
                return NotFound();
            }
            return missions.ToList();
        }


        [HttpGet (Name = "GetTasks")]
        public ActionResult<IEnumerable<Mission>> GetTasks(int ProjectId)
        {
            var missions = missionService.GetMissionsProject(ProjectId);
            if (missions == null)
            {
                return Ok("There is no tasks for this project");
            }
            return missions.ToList();
        }


        [HttpPost]
        public ActionResult<Mission> Post([FromBody] Mission mission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var newMission = missionService.CreateMission(mission);
            return Ok(newMission);
            
        }

        
        [HttpPut("{id}")]
        public ActionResult<Mission> Put(int id, [FromBody] Mission mission)
        {
            if(mission == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var newMission = missionService.EditMission(id, mission);
            return Ok(newMission);
        }

       
        [HttpDelete("{id}")]
        public ActionResult<Mission> Delete(int id)
        {
            var mission = missionService.GetMission(id);
            if (mission == null)
            {
                return BadRequest();
            }
            missionService.DeleteMission(id);
            var newMissions = missionService.GetAll();
            return Ok(newMissions);
        }
    }
}
