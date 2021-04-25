using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindTeacher.Models
{
    public class TeacherEducation
    {
        public int Id { get; set; }
        public string UniversityName { get; set; }
        public string Speciality { get; set; }
        public string Duration { get; set; }
        public int? TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
