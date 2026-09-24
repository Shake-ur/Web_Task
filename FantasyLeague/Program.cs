using FantasyLeague.Controllers;
using FantasyLeague.Models;

namespace FantasyLeague;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var apiKey = builder.Configuration["LolEsports:ApiKey"] ?? "0TvQnueqKa5mxJntVWt0w4LpLfEkrV1Ta8rQBb9Z";
        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddHttpClient<LoLEsportsScheduler>(client =>
        {
            client.BaseAddress = new Uri("https://esports-api.lolesports.com/persisted/gw/");
            client.DefaultRequestHeaders.Add("x-api-key", apiKey);
        });
        builder.Services.AddHttpClient<RiotNewsSourcer>();
        builder.Services.AddScoped<INewsSource,  RiotNewsSourcer>();
        builder.Services.AddScoped<NewsAggregator>();
        builder.Services.AddScoped<NewsRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();
        app.MapGet("/api/lolesports/live", async (LoLEsportsScheduler scheduler, CancellationToken ct) =>
        {
            var events = await scheduler.GetLiveEventsAsync(ct);
            return Results.Ok(events);
        });
        app.MapGet("/api/lolesports/schedule", async (LoLEsportsScheduler scheduler, string? leagueId = null, CancellationToken ct = default) =>
        {
            var events = await scheduler.GetScheduleEventsAsync(leagueId, ct);
            return Results.Ok(events);
        });
        app.MapGet("/api/lolesports/leagues", async (LoLEsportsScheduler scheduler, CancellationToken ct = default) =>
        {
            var leagues = await scheduler.GetLeaguesAsync(ct);
            return Results.Ok(leagues);
        });
        app.MapStaticAssets();
        app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.Run();
    }
}