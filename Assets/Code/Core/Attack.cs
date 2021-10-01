using Interfaces;
using UnityEngine;

public class Attack : CommandExecutorBase<IAttackCommand>
{
    public override void ExecuteSpecificCommand(IAttackCommand command)
    {
        Debug.Log("Command attack");
    }
}
