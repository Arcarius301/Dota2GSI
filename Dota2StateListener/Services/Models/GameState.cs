namespace Dota2StateListener.Services.Models
{
    public class GameState
    {
        [JsonPropertyName("buildings")]
        public Buildings? Buildings { get; set; }
        [JsonPropertyName("provider")]
        public Provider? Provider { get; set; }
        [JsonPropertyName("map")]
        public Map? Map { get; set; }
        [JsonPropertyName("player")]
        public Player? Player { get; set; }
        [JsonPropertyName("hero")]
        public Hero? Hero { get; set; }
        [JsonPropertyName("abilities")]
        public Dictionary<string, Ability>? Abilities { get; set; }
        [JsonPropertyName("items")]
        public Dictionary<string, Item>? Items { get; set; }
        [JsonPropertyName("draft")]
        public object? Draft { get; set; }
        [JsonPropertyName("wearables")]
        public Dictionary<string, int>? Wearables { get; set; }
    }
}
