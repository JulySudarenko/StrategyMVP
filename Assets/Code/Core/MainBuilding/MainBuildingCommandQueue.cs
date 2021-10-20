using Interfaces;
using UnityEngine;
using Zenject;

public class MainBuildingCommandQueue : MonoBehaviour, ICommandsQueue
{
    [Inject] private CommandExecutorBase<IProduceUnitCommand> _produceUnitCommandExecutor;
    [Inject] private CommandExecutorBase<ISetRallyPointCommand> _setRallyPointCommandExecutor;

    public ICommand CurrentCommand => default;

    public void Clear()
    {
    }

    public async void EnqueueCommand(object command)
    {
        await _produceUnitCommandExecutor.TryExecuteCommand(command);
        await _setRallyPointCommandExecutor.TryExecuteCommand(command);
    }
}
