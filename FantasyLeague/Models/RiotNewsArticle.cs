namespace FantasyLeague.Models
{
    public class RiotNewsArticle
    {
        public string Title { get; set; } = "";

        public DateTime PublishedAt { get; set; }

        public RiotAction? Action { get; set; }

        public RiotMedia? Media { get; set; }

        public RiotDescription? Description { get; set; }
    }

    public class RiotAction
    {
        public RiotPayload? Payload { get; set; }
    }

    public class RiotPayload
    {
        public string? Url { get; set; }
    }

    public class RiotMedia
    {
        public string? Url { get; set; }
    }

    public class RiotDescription
    {
        public string? Body { get; set; }
    }
}
