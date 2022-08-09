using System.Runtime.ConstrainedExecution;

namespace Dota2StateListener.Services.Models
{
    public class Player
    {
        [JsonPropertyName("steamid")]
        public string SteamId { get; set; } = null!;
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;
        [JsonPropertyName("activity")]
        public string Activity { get; set; } = null!;
        [JsonPropertyName("kills")]
        public int Kills { get; set; }
        [JsonPropertyName("deaths")]
        public int Deaths { get; set; }
        [JsonPropertyName("assists")]
        public int Assists { get; set; }
        [JsonPropertyName("last_hits")]
        public int LastHits { get; set; }
        [JsonPropertyName("denies")]
        public int Denies { get; set; }
        [JsonPropertyName("kill_streak")]
        public int KillStreak { get; set; }
        [JsonPropertyName("commands_issued")]
        public int CommandsIssued { get; set; }
        [JsonPropertyName("kill_list")]
        public Dictionary<string, int> KillList { get; set; } = null!;
        [JsonPropertyName("team_name")]
        public string TeamName { get; set; } = null!;
        [JsonPropertyName("gold")]
        public int Gold { get; set; }
        [JsonPropertyName("gold_reliable")]
        public int GoldReliable { get; set; }
        [JsonPropertyName("gold_unreliable")]
        public int GoldUnreliable { get; set; }
        [JsonPropertyName("gold_from_hero_kills")]
        public int GoldFromHeroKills { get; set; }
        [JsonPropertyName("gold_from_creep_kills")]
        public int GoldFromCreepKills { get; set; }
        [JsonPropertyName("gold_from_income")]
        public int GoldFromIncome { get; set; }
        [JsonPropertyName("gold_from_shared")]
        public int GoldFromShared { get; set; }
        [JsonPropertyName("gpm")]
        public int GoldPerMinute { get; set; }
        [JsonPropertyName("xpm")]
        public int ExperiencePerMinute { get; set; }
    }
}
