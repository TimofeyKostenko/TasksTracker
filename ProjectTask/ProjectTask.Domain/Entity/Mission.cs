using ProjectTask.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjectTask.Domain.Entity
{
    public class Mission  // represents the entity - Task
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Task name")]
        [Required(ErrorMessage = "Enter a task name")]
        public string? MissionName { get; set; }

        [Display(Name = "Priject ID")]
        [Required(ErrorMessage = "Enter a project ID")]
        public int ProjectId { get; set; }

        [Display(Name = "Task description")]
        [Required(ErrorMessage = "Enter a task description")]
        public string? Description { get; set; }


        public MissionStatus Status { get; set; }

        public int Priority { get; set; }
    }
}
