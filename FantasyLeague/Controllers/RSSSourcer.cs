using FantasyLeague.Models;

namespace FantasyLeague.Controllers
{
    public class RSSSourcer : INewsSource
    {
        private readonly HttpClient _http;
        public string Name { get; private set; }
        public string Url { get; private set; }
        public RSSSourcer(HttpClient http, string url)
        {
            _http = http;
            Url = url;
        }
        public async Task<IEnumerable<NewsArticle>> FetchArticlesAsync(CancellationToken ct)
        {
            var xml = await _http.GetStringAsync(Url, ct);
            //parsing
            List<NewsArticle> articles = new List<NewsArticle>();
            return articles;
        }
    }
}
