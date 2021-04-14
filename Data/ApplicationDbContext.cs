using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;
using System.Threading.Tasks;
using FindTeacher.Models;

namespace FindTeacher.Data
{
   
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<SystemFeedback> SystemFeedbacks { get; set; }
        public DbSet<SystemFeedbackCategory> SystemFeedbackCategories { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
