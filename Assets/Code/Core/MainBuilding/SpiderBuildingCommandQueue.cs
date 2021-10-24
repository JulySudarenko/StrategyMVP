using UnityEngine;


public sealed class SpiderBuildingCommandQueue : MainBuildingCommandQueue
{
    [SerializeField] private ProduceSpiderExecutor _produceSpiderCommandExecutor;

    public override async void EnqueueCommand(object command)
    {
        await _produceSpiderCommandExecutor.TryExecuteCommand(command);
    }
}   

