using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindTeacher.Models
{
    public class TeacherExperience
    {
        public int Id { get; set; }
        public string ExperienceTitle { get; set; }
        public string Duration { get; set; }
        public int? TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
