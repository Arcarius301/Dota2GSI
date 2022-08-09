using System.Diagnostics;
using Discord.Audio;
using Discord.Commands;
using Discord.WebSocket;

namespace Dota2GSI.Services
{
    public class DiscordBotService : IDiscordBotService
    {
        private readonly IEventService _eventService;
        private readonly DiscordSocketClient _client;
        private readonly DiscordOptions _discordOptions;
        private IAudioClient? _audioClient;
        private AudioOutStream _audioStream;

        public DiscordBotService(
            IOptions<DiscordOptions> options,
            IEventService eventService)
        {
            _discordOptions = options.Value;
            _eventService = eventService;

            var config = new DiscordSocketConfig
            {
                AlwaysDownloadUsers = _discordOptions.AlwaysDownloadUsers,
                MessageCacheSize = _discordOptions.MessageCacheSize
            };

            _client = new DiscordSocketClient(config);
        }

        public async Task RunAsync()
        {
            await _client.LoginAsync(TokenType.Bot, _discordOptions.Token);
            await _client.StartAsync();

            _client.Ready += () =>
            {
                Console.WriteLine($"Start listening for Dog Crate");
                return Task.CompletedTask;
            };

            _client.Log += ClientLog;
            _client.UserVoiceStateUpdated += async (arg1, arg2, arg3) => await OnUserJoin(arg1, arg2, arg3);
            _client.UserVoiceStateUpdated += async (arg1, arg2, arg3) => await OnUserMoved(arg1, arg2, arg3);
            await Task.Delay(-1);
        }

        [Command("join", RunMode = RunMode.Async)]
        public async Task JoinChannel(IVoiceChannel voiceChannel)
        {
            _audioClient = await voiceChannel.ConnectAsync();
            _audioStream = _audioClient.CreatePCMStream(AudioApplication.Mixed, 1920, 1000, 30);
        }

        public async Task SendAsync(string path)
        {
            if (_audioClient == null)
            {
                return;
            }

            using (var ffmpeg = CreateStream(path))
            using (var output = ffmpeg.StandardOutput.BaseStream)
            {
                try
                {
                    await output.CopyToAsync(_audioStream);
                }
                finally
                {
                    await _audioStream.FlushAsync();
                }
            }
        }

        private Task ClientLog(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }

        private Task OnUserJoin(SocketUser socketUser, SocketVoiceState socketVoiceState, SocketVoiceState socketVoiceState2)
        {
            if (socketVoiceState.VoiceChannel?.Id != socketVoiceState2.VoiceChannel?.Id
                && socketVoiceState.VoiceChannel?.Id == null
                && _discordOptions.ObservedUserIds.Contains(socketUser.Id))
            {
                var discordUser = new DiscordUser
                {
                    UserName = socketUser.Username,
                    FromChannelName = socketVoiceState.VoiceChannel?.Name,
                    ToChannelName = socketVoiceState2.VoiceChannel?.Name
                };

                // _eventService.DiscordUserMoved(discordUser);
            }

            return Task.CompletedTask;
        }

        private Task OnUserMoved(SocketUser socketUser, SocketVoiceState socketVoiceState, SocketVoiceState socketVoiceState2)
        {
            if (socketVoiceState.VoiceChannel?.Id != socketVoiceState2.VoiceChannel?.Id
                && socketVoiceState2.VoiceChannel?.Id != null
                && socketUser.Id == 385980824639504384)
            {
                _eventService.SuspectMoved(socketVoiceState2.VoiceChannel);
            }

            return Task.CompletedTask;
        }

        private Process? CreateStream(string path)
        {
            return Process.Start(new ProcessStartInfo
            {
                FileName = "ffmpeg",
                Arguments = $"-hide_banner -loglevel panic -i \"{path}\" -ac 2 -f s16le -ar 48000 pipe:1",
                UseShellExecute = false,
                RedirectStandardOutput = true,
            });
        }
    }
}
