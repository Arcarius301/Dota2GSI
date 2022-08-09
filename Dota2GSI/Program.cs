namespace Dota2GSI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var start = new Startup();
            await start.Run();
        }
    }
}