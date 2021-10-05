using System;
using UnityEngine;
using UnityEngine.AI;

public class UnitMovementStop : MonoBehaviour, IAwaitable<AsyncExtensions.Void>
{
    public class StopAwaiter : AwaitedBase<AsyncExtensions.Void>
    {
        private readonly UnitMovementStop _unitMovementStop;

        public StopAwaiter(UnitMovementStop unitMovementStop)
        {
            _unitMovementStop = unitMovementStop;
            _unitMovementStop.OnStop += OnStop;
        }

        private void OnStop()
        {
            _unitMovementStop.OnStop -= OnStop;
            WaitingForResult(new AsyncExtensions.Void());
        }
    }

    public event Action OnStop;

    [SerializeField] private NavMeshAgent _agent;

    public void Update()
    {
        if (!_agent.pathPending)
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                {
                    OnStop?.Invoke();
                }
            }
        }
    }

    public IAwaiter<AsyncExtensions.Void> GetAwaiter() => new StopAwaiter(this);
}
