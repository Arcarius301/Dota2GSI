namespace Dota2StateListener.Services.Models
{
    public class Ability
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;
        [JsonPropertyName("level")]
        public int Level { get; set; }
        [JsonPropertyName("can_cast")]
        public bool CanCast { get; set; }
        [JsonPropertyName("passive")]
        public bool IsPassive { get; set; }
        [JsonPropertyName("ability_active")]
        public bool IsActivated { get; set; }
        [JsonPropertyName("cooldown")]
        public int Сooldown { get; set; }
        [JsonPropertyName("ultimate")]
        public bool IsUltimate { get; set; }
    }
}
