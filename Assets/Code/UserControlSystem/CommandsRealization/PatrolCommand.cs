using Interfaces;
using UnityEngine;

namespace CommandsRealization
{
    public sealed class PatrolCommand : IPatrolCommand
    {
        public PatrolCommand()
        {
            Debug.Log("Patrol constructor is work");
        }
    }
}
