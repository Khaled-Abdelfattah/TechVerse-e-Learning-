namespace TechVerse.Models
{
    public class Announcement
    {
        public int AnnounceID { get; private set; }
        public string Title { get; private set; }
        public string? Publisher { get; private set; }
        public string? Summary { get; private set; }
        public DateTime PublishDate { get; private set; }

        protected Announcement() { Title = null!; }

        public Announcement(string title, string? summary, string? publisher)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty");

            Title = title;
            Summary = summary;
            PublishDate = DateTime.UtcNow;
            Publisher = publisher;
        }

        public void UpdateInfo(string newTitle, string? newSummary,string? newPublisher)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
                throw new ArgumentException("Title cannot be empty");

            Title = newTitle;
            Summary = newSummary;
            Publisher = newPublisher;
        }
    }
}