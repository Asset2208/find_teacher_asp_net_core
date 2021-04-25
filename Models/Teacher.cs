using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FindTeacher.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BirthDate { get; set; }
        public string Title { get; set; }
        public bool IsTeachOnline { get; set; }
        public string SubjectsTitle { get; set; }
        public string Story { get; set; }
        public string ImageUrl { get; set; }
        public bool IsEnabledAccount { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int? CityId { get; set; }
        public virtual City City { get; set; }
        public TeacherAchievement TeacherAchievement { get; set; }
        public TeacherEducation TeacherEducation { get; set; }
        public TeacherExperience TeacherExperience { get; set; }
        public bool Is_Filled_Education { get; set; }
        public bool Is_Filled_Experience { get; set; }
        public bool Is_Filled_Achievement { get; set; }
    }
}
