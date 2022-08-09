namespace Dota2GSI.Services.Abstractions
{
    public interface IDiscordBotService
    {
        public Task RunAsync();

        public Task JoinChannel(IVoiceChannel voiceChannel);

        public Task SendAsync(string path);
    }
}
