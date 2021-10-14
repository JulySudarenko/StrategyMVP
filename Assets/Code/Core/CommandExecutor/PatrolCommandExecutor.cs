using System.Threading.Tasks;
using Interfaces;
using UnityEngine;

public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
{
    public override async Task ExecuteSpecificCommand(IPatrolCommand command)
    {
        Debug.Log($"Command patrol from {command.GoFrom} to {command.GoTo}");
    }
}
