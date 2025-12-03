namespace TechVerse.Models
{
    public enum CourseLevel
    {
        Beginner,
        Intermediate,
        Advanced
    }

    public enum CourseStatus
    {
        Draft,
        Published,
        Archived
    }

    public class Course
    {
        public int CourseID { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Category { get; private set; }
        public float Price { get; private set; }
        public float Rating { get; private set; } 
        public int DurationHours { get; private set; }

        public CourseLevel Level { get; private set; }
        public CourseStatus Status { get; private set; }
        
        public virtual ICollection<Enrollment> Enrollments { get; private set; } = new List<Enrollment>();
        public virtual ICollection<Module> Modules { get; private set; } = new List<Module>();
        public virtual ICollection<Exam> Exams { get; private set; } = new List<Exam>();

        protected Course() { }
        public Course(string title, string description, float price, CourseLevel level)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title is required");
            if (price < 0) throw new ArgumentException("Price cannot be negative");

            Title = title;
            Description = description;
            Price = price;
            Level = level;

            Status = CourseStatus.Draft;
            Rating = 0;
            DurationHours = 0;
        }

        public void Publish()
        {
            if (Modules.Count == 0)
                throw new InvalidOperationException("Cannot publish an empty course.");

            Status = CourseStatus.Published;
        }

        public void UpdateInfo(string title, string description, float price)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title is required");
            Title = title;
            Description = description;
            Price = price;
        }

        public void AddModule(Module module)
        {
            if (module == null) throw new ArgumentNullException(nameof(module));
            Modules.Add(module);
        }
    }
}