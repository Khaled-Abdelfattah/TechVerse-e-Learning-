namespace TechVerse.Models
{
    public class Course
    {
        public int CourseID { get; private set; }// Primary Key
        public string Title { get; private set; }
        public string Category { get; private set; }
        public int DurationHours { get; private set; }
        
        public virtual ICollection<Module> Modules { get; private set; } = new List<Module>();
        public virtual ICollection<Exam> Exams { get; private set; } = new List<Exam>();

        protected Course() 
        {
            Title = null!;             
            Category = null!;
        }
        public Course(string title,string category)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title is required");

            Title = title;
            Category = category;
            DurationHours = 0;
        }

        public void AddModule(Module module)
        {
            if (module == null) throw new ArgumentNullException(nameof(module));
            Modules.Add(module);
        }
    }
}