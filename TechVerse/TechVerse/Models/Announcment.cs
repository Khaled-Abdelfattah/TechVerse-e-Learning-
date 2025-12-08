namespace TechVerse.Models
{
    public class Announcement
    {
        public int AnnounceID { get; private set; }
        public string? Title { get; private set; }
        public string? Summary { get; private set; }
        public DateTime PublishDate { get; private set; }

        protected Announcement() { }

        public Announcement(string title, string summary)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty");

            Title = title;
            Summary = summary;
            PublishDate = DateTime.UtcNow;
        }

        public void UpdateInfo(string newTitle, string newSummary)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
                throw new ArgumentException("Title cannot be empty");

            Title = newTitle;
            Summary = newSummary;
        }
    }
}