using Microsoft.EntityFrameworkCore;
using TechVerse.Models;

namespace TechVerse.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(@"Data Source=localhost\MSSQLSERVERS;Database=TechVerseDB;Integrated Security=True;TrustServerCertificate=True;");
            }
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<VideoModule> VideoModules { get; set; }
        public DbSet<TextModule> TextModules { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasKey(s => s.UserID);

            modelBuilder.Entity<Announcement>().HasKey(a => a.AnnounceID);

            modelBuilder.Entity<Course>().HasKey(c => c.CourseID);

            modelBuilder.Entity<Module>().HasKey(m => m.ModuleID);

            modelBuilder.Entity<Exam>().HasKey(e => e.ExamID);

            modelBuilder.Entity<Submission>().HasKey(s => s.SubmissionID);

            modelBuilder.Entity<Enrollment>()
                .HasKey(e => new { e.UserID, e.CourseID });

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Submission>()
                .HasOne(s => s.Student)
                .WithMany(st => st.Submissions)
                .HasForeignKey(s => s.UserID);

            modelBuilder.Entity<Submission>()
                .HasOne(s => s.Exam)
                .WithMany()
                .HasForeignKey(s => s.ExamID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Module>()
                .HasOne(m => m.Course)
                .WithMany(c => c.Modules)
                .HasForeignKey(m => m.CourseID);

            modelBuilder.Entity<Exam>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Exams)
                .HasForeignKey(e => e.CourseID);
        }
    }
}