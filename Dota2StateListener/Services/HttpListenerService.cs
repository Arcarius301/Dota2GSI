namespace Dota2StateListener.Services
{
    internal class HttpListenerService : IDisposable, IHttpListenerService
    {
        private HttpListener _httpListener;
        private Stream? _stream;

        public HttpListenerService(string uriPrefix)
        {
            _httpListener = new HttpListener();
            _stream = null;
            _httpListener.Prefixes.Add(uriPrefix);
        }

        public event Action<ReadOnlyMemory<char>>? OnDataReceived;

        public async Task Start()
        {
            _httpListener.Start();

            while (true)
            {
                try
                {
                    var context = await _httpListener.GetContextAsync();
                    await Task.Run(async () => await ProcessRequestAsync(context));
                }
                catch (HttpListenerException)
                {
                    break;
                }
                catch (InvalidOperationException)
                {
                    break;
                }
            }
        }

        public void Stop() => _httpListener.Stop();
        public void Dispose() => _httpListener.Close();

        private async Task ProcessRequestAsync(HttpListenerContext context)
        {
            try
            {
                var length = (int)context.Request.ContentLength64;
                var buffer = new byte[length];
                using (_stream = context.Request.InputStream)
                {
                    await _stream.ReadAsync(buffer.AsMemory(0, length));
                }

                ReadOnlyMemory<char> msg = Encoding.UTF8.GetChars(buffer);

                OnDataReceived?.Invoke(msg);

                context.Response.StatusCode = (int)HttpStatusCode.OK;
                context.Response.StatusDescription = "OK";
                context.Response.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Request error: {ex}");
            }
        }
    }
}
