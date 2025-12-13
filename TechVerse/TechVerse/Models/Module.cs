namespace TechVerse.Models
{
    public abstract class Module
    {
        public int ModuleID { get; private set; }
        public string Title { get; private set; }

        public abstract string ModuleType { get; }

        public int CourseID { get; private set; }

        public virtual Course? Course { get; private set; }

        protected Module() { Title = null!; }

        protected Module(string title, int courseId)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty");
            if (courseId <= 0)
                throw new ArgumentException("Invalid Course ID");

            Title = title;
            CourseID = courseId;
        }
    }

    public class VideoModule : Module
    {
        public string VideoUrl { get; private set; }

        public override string ModuleType => "Video";

        protected VideoModule() { VideoUrl = null!; }

        public VideoModule(string title, int courseId, string videoUrl)
            : base(title, courseId)
        {
            if (string.IsNullOrWhiteSpace(videoUrl))
                throw new ArgumentException("Video URL is required");

            VideoUrl = videoUrl;
        }
    }

    public class TextModule : Module
    {
        public string TextDescription { get; private set; }
        public override string ModuleType => "Text";
        protected TextModule() { TextDescription = null!; }
        public TextModule(string title, int courseId, string textDescription)
            : base(title, courseId)
        {
            if (string.IsNullOrWhiteSpace(textDescription))
                throw new ArgumentException("Text content is required");

            TextDescription = textDescription;
        }
    }
}