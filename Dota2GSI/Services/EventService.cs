namespace Dota2GSI.Services
{
    public class EventService : IEventService
    {
        public event Func<DiscordUser, Task>? OnDiscordUserMoved;
        public event Func<IVoiceChannel, Task>? OnSuspectMoved;
        public void DiscordUserMoved(DiscordUser discordUser)
        {
            OnDiscordUserMoved?.Invoke(discordUser);
        }

        public void SuspectMoved(IVoiceChannel voiceChannel)
        {
            OnSuspectMoved?.Invoke(voiceChannel);
        }
    }
}
