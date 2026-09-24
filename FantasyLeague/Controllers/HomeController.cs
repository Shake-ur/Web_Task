using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FantasyLeague.Models;
using FantasyLeague.ViewModels;

namespace FantasyLeague.Controllers;

public class HomeController : Controller
{
    private readonly INewsSource _newsSource;
    public HomeController(INewsSource newsSource)
    {
        _newsSource = newsSource; 
    }
    public async Task<IActionResult> Index()
    {
        var articles = await _newsSource.FetchArticlesAsync(CancellationToken.None);
        var model = new IndexViewModel { News = articles.ToList()};
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Schedule()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}