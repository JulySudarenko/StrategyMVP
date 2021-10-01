using Interfaces;
using UnityEngine;

public class Patrol : CommandExecutorBase<IPatrolCommand>
{
    public override void ExecuteSpecificCommand(IPatrolCommand command)
    {
        Debug.Log("Command patrol");
    }
}
