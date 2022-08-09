namespace Dota2GSI.Services.Abstractions
{
    public interface IEventService
    {
        public event Func<DiscordUser, Task>? OnDiscordUserMoved;
        public event Func<IVoiceChannel, Task>? OnSuspectMoved;
        public void DiscordUserMoved(DiscordUser discordUser);
        public void SuspectMoved(IVoiceChannel voiceChannel);
    }
}
