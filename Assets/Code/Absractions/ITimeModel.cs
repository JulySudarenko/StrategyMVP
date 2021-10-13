using System;

namespace Interfaces
{
    public interface ITimeModel
    {
        IObservable<int> GameTime { get; }
        void Pause();
        void ReturnToGame();
    }
}
