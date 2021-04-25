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
   
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<SystemFeedback> SystemFeedbacks { get; set; }
        public DbSet<SystemFeedbackCategory> SystemFeedbackCategories { get; set; }
        public DbSet<CommentPost> CommentPosts { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectBranch> SubjectBranches { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherAchievement> TeacherAchievements { get; set; }
        public DbSet<TeacherEducation> TeacherEducations { get; set; }
        public DbSet<TeacherExperience> TeacherExperiences { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
