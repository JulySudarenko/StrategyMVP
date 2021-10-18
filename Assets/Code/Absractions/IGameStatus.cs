using System;

namespace Interfaces
{
    public interface IGameStatus
    {
        IObservable<int> Status { get; }
    }
}
