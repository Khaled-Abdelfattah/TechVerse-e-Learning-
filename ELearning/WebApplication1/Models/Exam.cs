namespace TechVerse.Models
{
    public class Exam
    {
        public int ExamID { get; private set; }
        public string Title { get; private set; }
        public int TimeLimit { get; private set; } 
        public int TotalQuestions { get; private set; }

        public int CourseID { get; private set; }
        public Course Course { get; private set; } 

        protected Exam() { }

        public Exam(string title, int timeLimit, int totalQuestions, int courseId)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Exam title is required.");
            if (timeLimit <= 0)
                throw new ArgumentException("Time limit must be positive.");
            if (courseId <= 0)
                throw new ArgumentException("Invalid Course ID.");

            Title = title;
            TimeLimit = timeLimit;
            TotalQuestions = totalQuestions;
            CourseID = courseId;
        }

        public void UpdateDetails(string title, int timeLimit, int totalQuestions)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title required");

            Title = title;
            TimeLimit = timeLimit;
            TotalQuestions = totalQuestions;
        }
    }
}
