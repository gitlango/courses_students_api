using Microsoft.EntityFrameworkCore;

namespace StudentsAPI.Model
{
    public class Context : DbContext
    {
        public DbSet <Student> Students { get; set; }
        public DbSet <CourseStudent> CourseStudents { get; set; }
        public DbSet<Course> Courses { get; set; }

        public Context(DbContextOptions<Context> contextOptions) : base(contextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseStudent>().HasKey(sc => new { sc.StudentId, sc.CourseId });
        }
    }
}
