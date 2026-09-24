
using FantasyLeague.Models;

namespace FantasyLeague.Controllers
{
    public class NewsRepository
    {
        List<NewsArticle> Articles;
        public NewsRepository()
        {
          Articles = new List<NewsArticle>();  
        }

        public async Task AddIfNotExistsAsync(NewsArticle article, CancellationToken ct)
        {
            if(!Articles.Exists(articleId => articleId.SourceName == article.SourceName && articleId.Title == article.Title))
            {
                Articles.Add(article);
            }
        }
    }
}
