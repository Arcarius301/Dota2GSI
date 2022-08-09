namespace Dota2StateListener.Services.Abstractions
{
    internal interface IHttpListenerService
    {
        public event Action<ReadOnlyMemory<char>>? OnDataReceived;
        public Task Start();
        public void Stop();
    }
}
