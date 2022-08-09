namespace Dota2StateListener.Services.Models
{
    public class Map
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;
        [JsonPropertyName("matchid")]
        public string MatchId { get; set; } = null!;
        [JsonPropertyName("game_time")]
        public int GameTime { get; set; }
        [JsonPropertyName("clock_time")]
        public int ClockTime { get; set; }
        [JsonPropertyName("daytime")]
        public bool IsDayTime { get; set; }
        [JsonPropertyName("nightstalker_night")]
        public bool IsNightstalkerNight { get; set; }
        [JsonPropertyName("radiant_score")]
        public int? RadiantScore { get; set; }
        [JsonPropertyName("dire_score")]
        public int? DireScore { get; set; }
        [JsonPropertyName("game_state")]
        public string MatchState { get; set; } = null!;
        [JsonPropertyName("paused")]
        public bool IsPaused { get; set; }
        [JsonPropertyName("win_team")]
        public string WinTeam { get; set; } = null!;
        [JsonPropertyName("customgamename")]
        public string CustomGameName { get; set; } = null!;
        [JsonPropertyName("ward_purchase_cooldown")]
        public int WardPurchaseCooldown { get; set; }
    }
}
