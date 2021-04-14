using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindTeacher.Models
{
    public class SystemFeedback
    {
        public int Id { get; set; }
        public string UserFullName { get; set; }
        public string UserEmail { get; set; }
        public string Message { get; set; }
        public int? SystemFeedbackCategoryId { get; set; }
        public SystemFeedbackCategory SystemFeedbackCategory { get; set; }
    }
}
