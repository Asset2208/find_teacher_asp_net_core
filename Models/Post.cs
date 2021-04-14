using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindTeacher.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public string ImageUrl { get; set; }
        public int Views { get; set; }
        public bool Enabled { get; set; }
        public bool Comments_enabled { get; set; }
        public int? PostCategoryId { get; set; }
        public PostCategory PostCategory { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public Post()
        {
            Comments = new List<Comment>();
        }
    }
}
