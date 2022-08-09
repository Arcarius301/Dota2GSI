namespace Dota2StateListener.Services.Models
{
    public class Hero
    {
        [JsonPropertyName("xpos")]
        public int PositionX { get; set; }
        [JsonPropertyName("ypos")]
        public int PositionY { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;
        [JsonPropertyName("level")]
        public int Level { get; set; }
        [JsonPropertyName("xp")]
        public int Experience { get; set; }
        [JsonPropertyName("alive")]
        public bool IsAlive { get; set; }
        [JsonPropertyName("respawn_seconds")]
        public int SecondsToRespawn { get; set; }
        [JsonPropertyName("buyback_cost")]
        public int BuybackCost { get; set; }
        [JsonPropertyName("buyback_cooldown")]
        public int BuybackCooldown { get; set; }
        [JsonPropertyName("health")]
        public int Health { get; set; }
        [JsonPropertyName("max_health")]
        public int MaxHealth { get; set; }
        [JsonPropertyName("health_percent")]
        public int HealthPercent { get; set; }
        [JsonPropertyName("mana")]
        public int Mana { get; set; }
        [JsonPropertyName("max_mana")]
        public int MaxMana { get; set; }
        [JsonPropertyName("mana_percent")]
        public int ManaPercent { get; set; }
        [JsonPropertyName("silenced")]
        public bool IsSilenced { get; set; }
        [JsonPropertyName("stunned")]
        public bool IsStunned { get; set; }
        [JsonPropertyName("disarmed")]
        public bool IsDisarmed { get; set; }
        [JsonPropertyName("magicimmune")]
        public bool IsMagicImmune { get; set; }
        [JsonPropertyName("hexed")]
        public bool IsHexed { get; set; }
        [JsonPropertyName("muted")]
        public bool IsMuted { get; set; }
        [JsonPropertyName("break")]
        public bool IsBreak { get; set; }
        [JsonPropertyName("aghanims_scepter")]
        public bool HasAghanimsScepterBuff { get; set; }
        [JsonPropertyName("aghanims_shard")]
        public bool HasAghanimsShardBuff { get; set; }
        [JsonPropertyName("smoked")]
        public bool IsSmoked { get; set; }
        [JsonPropertyName("has_debuff")]
        public bool HasDebuff { get; set; }
        [JsonPropertyName("talent_1")]
        public bool HasTalent1 { get; set; }
        [JsonPropertyName("talent_2")]
        public bool HasTalent2 { get; set; }
        [JsonPropertyName("talent_3")]
        public bool HasTalent3 { get; set; }
        [JsonPropertyName("talent_4")]
        public bool HasTalent4 { get; set; }
        [JsonPropertyName("talent_5")]
        public bool HasTalent5 { get; set; }
        [JsonPropertyName("talent_6")]
        public bool HasTalent6 { get; set; }
        [JsonPropertyName("talent_7")]
        public bool HasTalent7 { get; set; }
        [JsonPropertyName("talent_8")]
        public bool HasTalent8 { get; set; }
    }
}
