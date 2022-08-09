using Dota2StateListener.Services;
using Dota2StateListener.Services.Abstractions;

namespace Dota2GSI
{
    public class Application
    {
        private readonly IGameStateService _gameStateService;
        private readonly IDiscordBotService _discordBotService;
        private readonly IEventService _eventService;

        public Application(
            IGameStateService gameStateService,
            IDiscordBotService discordBotService,
            IEventService eventService)
        {
            _gameStateService = gameStateService;
            _discordBotService = discordBotService;
            _eventService = eventService;

            _eventService.OnSuspectMoved += async (voiceChannel) => await JoinChannel(voiceChannel);
            _gameStateService.OnPudgeDeath += async () => await _discordBotService.SendAsync(@"C:\Users\kompu\Downloads\zxc.mp3");
        }

        public async Task Run()
        {
            var list = new List<Task>();
            list.Add(Task.Run(async () => await _gameStateService.Start()));
            list.Add(Task.Run(async () => { await _discordBotService.RunAsync(); }));
            await Task.WhenAll(list);
        }

        private async Task JoinChannel(IVoiceChannel voiceChannel)
        {
            await Task.Delay(500);
            await _discordBotService.JoinChannel(voiceChannel);
        }
    }
}
