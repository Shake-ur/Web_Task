namespace FantasyLeague.Models
{
    public class NewsArticle
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        public string Url { get; set; } = null!;
        public string? ImageUrl { get; set; }

        public DateTime PublishedAt { get; set; }

        public string SourceName { get; set; } = null!;
        public string? Author { get; set; }

        public DateTime RetrievedAt { get; set; }
    }
}
