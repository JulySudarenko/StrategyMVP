using Interfaces;
using UnityEngine;

public class Stop : CommandExecutorBase<IStopCommand>
{
    public override void ExecuteSpecificCommand(IStopCommand command)
    {
        Debug.Log("Command stop");
    }
}
