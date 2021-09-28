using Interfaces;
using UnityEngine;

namespace CommandsRealization
{
    public sealed class StopCommand : IStopCommand
    {
        public StopCommand()
        {
            Debug.Log("Stop constructor is work");
        }
    }
}
