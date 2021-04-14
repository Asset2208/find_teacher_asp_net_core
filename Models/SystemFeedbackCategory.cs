using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindTeacher.Models
{
    public class SystemFeedbackCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<SystemFeedback> SystemFeedbacks { get; set; }
        public SystemFeedbackCategory()
        {
            SystemFeedbacks = new List<SystemFeedback>();
        }
    }
}
