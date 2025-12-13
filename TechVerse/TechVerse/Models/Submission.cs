namespace TechVerse.Models
{
    public class Submission
    {
        public int SubmissionID { get; private set; }
        public DateTime SubmitDate { get; private set; }
        public float Grade { get; private set; }
        public string? Feedback { get; private set; }
        public string? FileUrl { get; private set; }

        public int UserID { get; private set; }
        public Student? Student { get; private set; }

        public int ExamID { get; private set; }
        public Exam? Exam { get; private set; }

        protected Submission() { }

        public Submission(int userId, int examId, string fileUrl)
        {
            if (userId <= 0) throw new ArgumentException("Invalid Student ID");
            if (examId <= 0) throw new ArgumentException("Invalid Exam ID");
            if (string.IsNullOrWhiteSpace(fileUrl)) throw new ArgumentException("File URL is required");

            UserID = userId;
            ExamID = examId;
            FileUrl = fileUrl;

            SubmitDate = DateTime.UtcNow;
            Grade = 0; 
            Feedback = "Pending Review";
        }
        public string SubmitDateFormatted => SubmitDate.ToString("yyyy-MM-dd HH:mm:ss");    
    }
}