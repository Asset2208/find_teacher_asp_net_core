using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindTeacher.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SubjectBranch> SubjectBranches { get; set; }
        public Subject()
        {
            SubjectBranches = new List<SubjectBranch>();
        }
    }
}
