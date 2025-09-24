using System.Security.Cryptography.X509Certificates;
using TallinnaRakenduslikKolledzKaur.Models;
using Microsoft.EntityFrameworkCore;

namespace TallinnaRakenduslikKolledzKaur.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { } 
        public DbSet<Course> Courses { get; set; }
        public DbSet<Commendation> Commendations { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<CourseAssignment> courseAssignments { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Commendation>().ToTable("Commendation");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Mark>().ToTable("Mark");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Instructor>().ToTable("Instructor");
            modelBuilder.Entity<CourseAssignment>().ToTable("CourseAssignment");
            modelBuilder.Entity<OfficeAssignment>().ToTable("OfficeAssignment");
            modelBuilder.Entity<Department>().ToTable("Department");
            
        }
        
    }
}
