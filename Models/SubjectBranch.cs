using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindTeacher.Models
{
    public class SubjectBranch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
