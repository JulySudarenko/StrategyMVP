using Interfaces;
using UnityEngine;
using Zenject;

public class MainBuildingCommandQueue : MonoBehaviour, ICommandsQueue
{
     // [Inject] private CommandExecutorBase<IProduceChomperCommand> _produceChomperCommandExecutor;
     //  [Inject] private CommandExecutorBase<IProduceSpiderCommand> _produceSpiderCommandExecutor;
     
     // [Inject] private ProduceChomperExecutor _produceChomperCommandExecutor;
     // [Inject] private ProduceSpiderExecutor _produceSpiderCommandExecutor;
     [SerializeField] private ProduceChomperExecutor _produceChomperCommandExecutor;
     [SerializeField] private ProduceSpiderExecutor _produceSpiderCommandExecutor;
     [Inject] private CommandExecutorBase<ISetRallyPointCommand> _setRallyPointCommandExecutor;  

    public ICommand CurrentCommand => default;

    public void Clear()
    {
    }

    public async void EnqueueCommand(object command)
    {
        await _produceChomperCommandExecutor.TryExecuteCommand(command);
        await _produceSpiderCommandExecutor.TryExecuteCommand(command);
        await _setRallyPointCommandExecutor.TryExecuteCommand(command);
    }
}          
