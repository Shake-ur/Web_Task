using System.Text.Json.Serialization;

namespace FantasyLeague.Models
{
    public class LiveResponse
    {
        [JsonPropertyName("data")]
        public LiveData? Data { get; set; }
    }

    public class LiveData
    {
        [JsonPropertyName("schedule")]
        public Schedule? Schedule { get; set; }
    }

    public class ScheduleResponse
    {
        [JsonPropertyName("data")]
        public LiveData? Data { get; set; }
    }

    public class Schedule
    {
        [JsonPropertyName("events")]
        public List<EsportsEvent> Events { get; set; } = [];
    }

    public class EsportsEvent
    {
        [JsonPropertyName("startTime")]
        public DateTimeOffset StartTime { get; set; }

        [JsonPropertyName("state")]
        public string? State { get; set; } // "unstarted" | "inProgress" | "completed"

        [JsonPropertyName("blockName")]
        public string? BlockName { get; set; }

        [JsonPropertyName("league")]
        public LeagueRef? League { get; set; }

        [JsonPropertyName("match")]
        public MatchRef? Match { get; set; }
    }

    public class LeagueRef
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("slug")]
        public string? Slug { get; set; }
    }

    public class MatchRef
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("teams")]
        public List<TeamRef> Teams { get; set; } = [];
    }

    public class TeamRef
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("code")]
        public string? Code { get; set; }

        [JsonPropertyName("image")]
        public string? Image { get; set; }

        [JsonPropertyName("result")]
        public TeamResult? Result { get; set; }
    }

    public class TeamResult
    {
        [JsonPropertyName("gameWins")]
        public int GameWins { get; set; }
    }

    public class LeaguesResponse
    {
        [JsonPropertyName("data")]
        public LeaguesData? Data { get; set; }
    }

    public class LeaguesData
    {
        [JsonPropertyName("leagues")]
        public List<LeagueRef> Leagues { get; set; } = [];
    }
}
