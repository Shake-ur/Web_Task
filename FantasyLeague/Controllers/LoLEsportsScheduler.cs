using FantasyLeague.Models;
namespace FantasyLeague.Controllers
{
    public class LoLEsportsScheduler
    {
        private readonly HttpClient _httpClient;

        public LoLEsportsScheduler(HttpClient httpClient)
        { 
            _httpClient = httpClient;
        }
        public async Task<List<EsportsEvent>> GetLiveEventsAsync(CancellationToken ct = default)
        {
            var response = await _httpClient.GetFromJsonAsync<LiveResponse>("getLive?hl=en-US", ct);
            return response?.Data?.Schedule?.Events ?? [];
        }
        public async Task<List<EsportsEvent>> GetScheduleEventsAsync(string? leagueId = null,CancellationToken ct = default)
        {
            var url = "getSchedule?hl=en-US";
            if (!string.IsNullOrWhiteSpace(leagueId))
                url += $"&leagueId={leagueId}";

            var response = await _httpClient.GetFromJsonAsync<ScheduleResponse>(url, ct);
            return response?.Data?.Schedule?.Events ?? [];
        }
        public async Task<List<LeagueRef>> GetLeaguesAsync(CancellationToken ct = default)
        {
            var response = await _httpClient.GetFromJsonAsync<LeaguesResponse>("getLeagues?hl=en-US", ct);
            return response?.Data?.Leagues ?? [];
        }
    }
}
