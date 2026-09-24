namespace FantasyLeague.Models
{
    public interface INewsSource
    {
        string Name { get; }
        Task<IEnumerable<NewsArticle>> FetchArticlesAsync(CancellationToken ct);
    }
}
