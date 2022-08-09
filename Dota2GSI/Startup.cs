using Dota2StateListener.Services;
using Dota2StateListener.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Dota2GSI
{
    public class Startup
    {
        public async Task Run()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();

            var serviceProvider = new ServiceCollection()
                .AddOptions()
                .Configure<DiscordOptions>(config.GetSection("DiscordOptions"))
                .AddSingleton<IEventService, EventService>()
                .AddSingleton<IDiscordBotService, DiscordBotService>()
                .AddSingleton<IGameStateService>(x => new GameStateService("http://localhost:40000/"))
                .AddSingleton<Application>()
                .BuildServiceProvider();

            var app = serviceProvider.GetService<Application>();
            await app!.Run();
        }
    }
}
