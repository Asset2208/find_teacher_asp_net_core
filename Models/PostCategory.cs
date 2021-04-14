using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindTeacher.Models
{
    public class PostCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool Enabled { get; set; }
        public DateTime Created_date { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public PostCategory()
        {
            Posts = new List<Post>();
        }
    }
}
