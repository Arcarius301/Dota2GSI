namespace Dota2StateListener.Services.Models
{
    public class Buildings
    {
        [JsonPropertyName("radiant")]
        public Dictionary<string, Build>? Radiant { get; set; }
        [JsonPropertyName("dire")]
        public Dictionary<string, Build>? Dire { get; set; }
    }
}
