namespace Dota2GSI.Models
{
    public record DiscordUser
    {
        public string UserName { get; set; } = null!;
        public string? FromChannelName { get; set; }
        public string? ToChannelName { get; set; }
    }
}
