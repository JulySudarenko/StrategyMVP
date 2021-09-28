using Interfaces;
using UnityEngine;

public class Move : CommandExecutorBase<IMoveCommand>
{
    public override void ExecuteSpecificCommand(IMoveCommand command)
    {
        Debug.Log("Command move");
    }
}
