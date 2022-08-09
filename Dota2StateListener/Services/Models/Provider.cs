namespace Dota2StateListener.Services.Models
{
    public class Provider
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;
        [JsonPropertyName("appid")]
        public int ApplicationId { get; set; }
        [JsonPropertyName("version")]
        public int Version { get; set; }
        [JsonPropertyName("timestamp")]
        public int Timestamp { get; set; }
    }
}
