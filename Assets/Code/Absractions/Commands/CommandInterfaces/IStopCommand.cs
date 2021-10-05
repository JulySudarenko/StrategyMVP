using UnityEngine;


namespace Interfaces
{
    public interface IStopCommand : ICommand
    {
        public Vector3 HeldPosition { get; }
    }
}
