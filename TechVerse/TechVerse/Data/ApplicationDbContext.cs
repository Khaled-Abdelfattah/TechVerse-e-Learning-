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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.UserID);

                entity.Property(s => s.FullName)
                      .IsRequired()
                      .HasMaxLength(100); 

                entity.Property(s => s.Email)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.HasIndex(s => s.Email).IsUnique();

                entity.Property(s => s.Password)
                      .IsRequired()
                      .HasMaxLength(255); 

                entity.Property(s => s.Country)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(s => s.PhoneNumber)
                      .HasMaxLength(20);

                entity.Property(s => s.Age).IsRequired();
            });

            modelBuilder.Entity<Announcement>().HasKey(a => a.AnnounceID);

            modelBuilder.Entity<Course>().HasKey(c => c.CourseID);

            modelBuilder.Entity<Module>().HasKey(m => m.ModuleID);

            modelBuilder.Entity<Exam>().HasKey(e => e.ExamID);

            modelBuilder.Entity<Submission>().HasKey(s => s.SubmissionID);

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