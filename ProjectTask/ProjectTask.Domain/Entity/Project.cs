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
    public class Project  // represents entity - Project
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Project name")]
        [Required(ErrorMessage = "Enter a project name")]
        public string? ProjectName { get; set; }

        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Completion Date")]
        public DateTime? CompletionDate { get; set; }


        public ProjectStatus Status { get; set; }

        public int Priority { get; set; }

    }
}
