using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        
        public virtual ICollection<Notification> Notifications { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("StudentInternshipManagement", throwIfV1Schema: false)
        {
            Database.SetInitializer(new DataInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Semester> Semesters { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<StudentClass> StudentClasses { get; set; }

        public DbSet<LearningClass> LearningClasses { get; set; }

        public DbSet<LearningClassStudent> LearningClassStudents { get; set; }

        public DbSet<TrainingMajor> TrainingMajors { get; set; }

        public DbSet<CompanyTrainingMajor> CompanyTrainingMajors { get; set; }

        public DbSet<Internship> Internships { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<News> Newses { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Statistic> Statistics { get; set; }
    }
}