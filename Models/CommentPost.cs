using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindTeacher.Models
{
    public class CommentPost
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool Enabled { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public DateTime Created_date { get; set; }
        public int? PostId { get; set; }
        public Post Post { get; set; }
    }
}
