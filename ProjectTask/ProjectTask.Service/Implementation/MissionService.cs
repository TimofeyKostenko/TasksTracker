using ProjectTask.DAL.Interface;
using ProjectTask.Domain.Entity;
using ProjectTask.Service.Exceprtion;
using ProjectTask.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTask.Service.Implementation
{
    public class MissionService : IMissionService
    {
        private readonly IBaseRepository<Mission> missionRepo;

        public MissionService(IBaseRepository<Mission> missionRepo)
        {
            this.missionRepo = missionRepo;
        }
        public  Mission CreateMission(Mission mission)
        {
            var newMission = new Mission()
            {
                MissionName = mission.MissionName,
                ProjectId = mission.ProjectId,
                Description = mission.Description,
                Status = mission.Status,
                Priority = mission.Priority
            };
            missionRepo.Create(newMission);
            return newMission;
        }

        public async Task<bool> DeleteMission(int id)
        {
            var mission = missionRepo.Get(id);
            if (mission == null)
            {
                throw new ValidationException("There is no object with this id", "");
            }
            await missionRepo.Delete(mission);
            return true;
        }

        public async Task<Mission> EditMission(int id, Mission mission)
        {
            var changedMission = missionRepo.Get(id);
            if (changedMission == null)
            {
                throw new ValidationException("This object does not exist", "");
            };

            changedMission.MissionName = mission.MissionName;
            changedMission.ProjectId = mission.ProjectId;
            changedMission.Description = mission.Description;
            changedMission.Status = mission.Status;
            changedMission.Priority = mission.Priority;

            await missionRepo.Update(changedMission);
            return changedMission;
        }

        public IQueryable<Mission>? GetAll()
        {
            var missions = missionRepo.GetAll();
            if (missions == null)
            {
                throw new ValidationException("Table is empty", "");
            }
            return missions;
        }

        public Mission GetMission(int id)
        {
            var mission = missionRepo.Get(id);
            if (mission == null)
            {
                throw new ValidationException("This object does not exist", "");
            }
            return mission;
        }

        public IQueryable<Mission> GetMissionsProject(int projectId)
        {
            var missions = missionRepo.GetAll().Where(x => x.ProjectId == projectId);
            if (missions == null)
            {
                throw new ValidationException("This object does not exist", "");
            }
            return missions;
        }
    }
}
