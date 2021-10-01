using UnityEngine;

namespace Interfaces
{
    public interface IMoveCommand : ICommand
    {
        public Vector3 Target { get; }
    }
}
