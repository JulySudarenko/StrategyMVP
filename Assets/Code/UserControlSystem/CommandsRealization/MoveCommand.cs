using Interfaces;
using UnityEngine;

namespace CommandsRealization
{
    public sealed class MoveCommand : IMoveCommand
    {
        public Vector3 Target { get; }

        public MoveCommand(Vector3 target)
        {
            Target = target;
        }
    }
}
