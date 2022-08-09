using System.Drawing;

namespace Dota2StateListener.Services
{
    public class GameStateService : IGameStateService
    {
        private readonly IHttpListenerService _httpListenerService;
        private GameState? _newGameState;
        private GameState? _oldGameState;
        public GameStateService(string uriPrefix)
        {
            _httpListenerService = new HttpListenerService(uriPrefix);
            _httpListenerService.OnDataReceived += (data) => UpdateGameState(data);
        }

        public event Action<GameState?, GameState?>? OnGameStateChanged;
        public event Action<int>? OnClockTimeChanged;
        public event Action? OnPudgeDeath;
        public event Action? OnDangerZoneEntered;

        public async Task Start() => await _httpListenerService.Start();
        public void Stop() => _httpListenerService.Stop();

        private void UpdateGameState(in ReadOnlyMemory<char> data)
        {
            _oldGameState = _newGameState;
            try
            {
                _newGameState = JsonSerializer.Deserialize<GameState>(data.Span);
                OnGameStateChanged?.Invoke(_oldGameState, _newGameState);
            }
            catch (Exception)
            {
            }

            if (_oldGameState?.Map?.ClockTime
                != _newGameState?.Map?.ClockTime
                && _newGameState?.Map?.ClockTime != null)
            {
                OnClockTimeChanged?.Invoke(_newGameState.Map.ClockTime);
            }

            if ((_oldGameState?.Hero?.IsAlive == true)
                && (_newGameState?.Hero?.IsAlive == false)
                && _newGameState?.Hero?.Name == "npc_dota_hero_pudge")
            {
                OnPudgeDeath?.Invoke();
            }
        }

        private bool IsPointInPolygon4(PointInt[] polygon, PointInt point)
        {
            bool result = false;
            int j = polygon.Count() - 1;
            for (int i = 0; i < polygon.Count(); i++)
            {
                if ((polygon[i].Y < point.Y && polygon[j].Y >= point.Y) || (polygon[j].Y < point.Y && polygon[i].Y >= point.Y))
                {
                    if (polygon[i].X + ((point.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) * (polygon[j].X - polygon[i].X)) < point.X)
                    {
                        result = !result;
                    }
                }

                j = i;
            }

            return result;
        }
    }
}
