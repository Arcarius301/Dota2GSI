namespace Dota2StateListener.Services.Models
{
    public class Item
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;
        [JsonPropertyName("purchaser")]
        public int? Purchaser { get; set; }
        [JsonPropertyName("can_cast")]
        public bool? CanCast { get; set; }
        [JsonPropertyName("cooldown")]
        public int? Cooldown { get; set; }
        [JsonPropertyName("passive")]
        public bool? IsPassive { get; set; }
        [JsonPropertyName("charges")]
        public int? Charges { get; set; }
    }
}
