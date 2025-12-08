namespace TechVerse.Models
{ 
    public enum EnrollmentStatus
    {
        Active,
        Completed,
        Dropped,
        Archived
    }

    public class Enrollment
    {
        public int EnrollmentID { get; private set; }
        public DateTime EnrollDate { get; private set; }
        public float ProgressPercent { get; private set; }
        public EnrollmentStatus Status { get; private set; }

        public int UserID { get; private set; }

        public virtual Student? Student { get; private set; }

        public int CourseID { get; private set; }

        public virtual Course? Course { get; private set; }

        protected Enrollment() { }

        public Enrollment(int userId, int courseId)
        {
            if (userId <= 0) throw new ArgumentException("Invalid Student ID");
            if (courseId <= 0) throw new ArgumentException("Invalid Course ID");

            UserID = userId;
            CourseID = courseId;

            EnrollDate = DateTime.UtcNow;
            ProgressPercent = 0;
            Status = EnrollmentStatus.Active;
        }

        public void UpdateProgress(float newPercent)
        {
            if (newPercent < 0 || newPercent > 100)
                throw new ArgumentException("Progress must be between 0 and 100");

            if (newPercent < ProgressPercent)
                throw new InvalidOperationException("Cannot lower progress");

            ProgressPercent = newPercent;

            if (ProgressPercent == 100)
            {
                Status = EnrollmentStatus.Completed;
            }
        }
    }
}