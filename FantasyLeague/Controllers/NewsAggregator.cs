using FantasyLeague.Models;
namespace FantasyLeague.Controllers
{
    public class NewsAggregator
    {
        private readonly IEnumerable<INewsSource> _sources;
        private readonly NewsRepository _repository;
        private readonly ILogger<NewsAggregator> _logger;
        public NewsAggregator(
    IEnumerable<INewsSource> sources,
    NewsRepository repository,
    ILogger<NewsAggregator> logger)
        {
            _sources = sources;
            _repository = repository;
            _logger = logger;
        }

        public async Task UpdateAsync(CancellationToken ct)
        {
            foreach (var source in _sources)
            {
                try
                {
                    var articles = await source.FetchArticlesAsync(ct);
                    foreach (var article in articles)
                    {
                        await _repository.AddIfNotExistsAsync(article, ct);
                    }
                }

                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Failed to update news source {source.Name}", source.Name);
                }
            }
        }
    }
}