using UnityEngine;

public sealed class ChomperBuildingCommandQueue : MainBuildingCommandQueue
{
     [SerializeField] private ProduceChomperExecutor _produceChomperCommandExecutor;

    public override async void EnqueueCommand(object command)
    {
        await _produceChomperCommandExecutor.TryExecuteCommand(command);
    }
}