namespace TechVerse.Models
{
    public class SubCourse
    {
        public int SubCourseID { get; private set; }
        public string Title { get; private set; }
        public int Hours { get; private set; }
        public double Rating { get; private set; }

        public int CourseID { get; private set; }

        public virtual Course Course { get; private set; }

        protected SubCourse()
        {
            Title = null!;
            Course = null!;
        }

        public SubCourse(Course course, string title, int hours, double rating)
        {
            if (course == null)
                throw new ArgumentNullException(nameof(course));

            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty", nameof(title));

            if (hours < 0)
                throw new ArgumentException("Hours cannot be negative", nameof(hours));

            if (rating < 0 || rating > 5)
                throw new ArgumentException("Rating must be between 0 and 5", nameof(rating));

            Course = course;
            CourseID = course.CourseID; 
            Title = title;
            Hours = hours;
            Rating = rating;
        }

        public void UpdateRating(double newRating)
        {
            if (newRating < 0 || newRating > 5)
                throw new ArgumentException("Rating must be between 0 and 5");

            Rating = newRating;
        }
    }
}