using Interfaces;
using UnityEngine;

namespace CommandsRealization
{
    public sealed class PatrolCommand : IPatrolCommand
    {
        public Vector3 GoFrom { get; }
        public Vector3 GoTo { get; }

        public PatrolCommand(Vector3 goFrom, Vector3 goTo)
        {
            GoFrom = goFrom;
            GoTo = goTo;
        }
    }
}
