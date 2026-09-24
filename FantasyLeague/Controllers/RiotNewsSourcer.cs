using FantasyLeague.Models;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace FantasyLeague.Controllers
{
    public class RiotNewsSourcer : INewsSource
    {
        private readonly HttpClient _http;

        public string Name => "Riot";
        private const string Url = "https://soraclee.github.io/riotgames-news-api/data/lol/esportsEn.json";
        public RiotNewsSourcer(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<NewsArticle>> FetchArticlesAsync(
            CancellationToken cancellationToken)
        {
            var articleJson =
                await _http.GetStringAsync(
                    Url,
                    cancellationToken);
            var articles = JsonSerializer.Deserialize<List<RiotNewsArticle>>(articleJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            if (articles == null) {
                return [];
            }

            return articles?.Select(MapArticle)
                   ?? Enumerable.Empty<NewsArticle>();
        }

        private NewsArticle MapArticle(RiotNewsArticle article)
        {
            return new NewsArticle
            {
                Title = article.Title,
                Description = article.Description?.Body??"",
                Url = article.Action?.Payload?.Url ?? "",
                ImageUrl = article.Media?.Url ?? "",
                PublishedAt = article.PublishedAt,
                SourceName = Name,
                RetrievedAt = DateTime.UtcNow
            };
        }

    }
}
