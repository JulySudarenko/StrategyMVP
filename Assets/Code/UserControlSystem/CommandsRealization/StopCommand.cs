using Interfaces;
using UnityEngine;

namespace CommandsRealization
{
    public sealed class StopCommand : IStopCommand
    {
        public Vector3 HeldPosition { get; }
        public StopCommand(Vector3 currentPosition)
        {
            HeldPosition = currentPosition;
        }
    }
}
