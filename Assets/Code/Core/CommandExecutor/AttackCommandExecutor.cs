using System.Threading.Tasks;
using Interfaces;
using UnityEngine;

public class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>
{
    public override  async Task ExecuteSpecificCommand(IAttackCommand command)
    {
        Debug.Log($"Command attack {command.Target}");
    }
}