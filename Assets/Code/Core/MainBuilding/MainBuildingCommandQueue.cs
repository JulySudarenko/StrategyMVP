using Interfaces;
using UnityEngine;
using Zenject;

public class MainBuildingCommandQueue : MonoBehaviour, ICommandsQueue
{
    [Inject] private CommandExecutorBase<ISetRallyPointCommand> _setRallyPointCommandExecutor;  

    public ICommand CurrentCommand => default;

    public void Clear()
    {
    }

    public virtual async void EnqueueCommand(object command)
    {
        await _setRallyPointCommandExecutor.TryExecuteCommand(command);
    }
}
