using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota2StateListener.Services.Abstractions
{
    public interface IGameStateService
    {
        public event Action<int>? OnClockTimeChanged;
        public event Action? OnPudgeDeath;
        public event Action? OnDangerZoneEntered;

        public Task Start();
        public void Stop();
    }
}
