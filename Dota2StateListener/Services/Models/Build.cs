namespace Dota2StateListener.Services.Models
{
    public class Build
    {
        [JsonPropertyName("health")]
        public int Health { get; set; }
        [JsonPropertyName("max_health")]
        public int MaxHealth { get; set; }
    }
}
