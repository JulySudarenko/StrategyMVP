using Interfaces;
using UnityEngine;

namespace CommandsRealization
{
    public sealed class MoveCommand : IMoveCommand
    {
        public MoveCommand()
        {
            Debug.Log("Move constructor is work");
        }
    }
}
