using System.Threading;
using Interfaces;
using UnityEngine;
using UnityEngine.AI;
using Utils;

public class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
{
    [SerializeField] private UnitMovementStop _stop;
    [SerializeField] private Animator _animator;
    [SerializeField] private StopCommandExecutor _stopCommandExecutor;

    private NavMeshAgent _navMeshAgent;

    public override async void ExecuteSpecificCommand(IMoveCommand command)
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.destination = command.Target;
        _stopCommandExecutor.CancellationTokenSource = new CancellationTokenSource();
        _animator.SetTrigger("Walk");
        try
        {
            await _stop.WithCancellation(_stopCommandExecutor.CancellationTokenSource.Token);
        }
        catch
        {
            _navMeshAgent.isStopped = true;
            _navMeshAgent.ResetPath();
        }

        _animator.SetTrigger("Idle");
    }
}
