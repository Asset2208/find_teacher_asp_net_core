using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindTeacher.Models;

namespace FindTeacher.Models
{
    public class PostViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterPostViewModel FilterPostViewModel { get; set; }
    }
}
