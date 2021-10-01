using UnityEngine;

namespace Interfaces
{
    public interface IPatrolCommand : ICommand
    {
        public Vector3 GoFrom { get; }
        public Vector3 GoTo { get; }
    }
}
