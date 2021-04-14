using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FindTeacher.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string User_id { get; set; }
        public bool Enabled { get; set; }
        public virtual Microsoft.AspNetCore.Identity.IdentityUser IdentityUser { get; set; }
        public DateTime Created_date { get; set; }
        public int? PostId { get; set; }
        public Post Post { get; set; }
    }
}
