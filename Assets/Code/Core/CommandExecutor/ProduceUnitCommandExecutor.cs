using System.Threading.Tasks;
using Interfaces;
using UniRx;
using UnityEngine;
using Zenject;

public class ProduceUnitCommandExecutor : CommandExecutorBase<IProduceUnitCommand>, IUnitProducer
{
    public IReadOnlyReactiveCollection<IUnitProductionTask> Queue => _queue;

    [SerializeField] private int _maximumUnitsInQueue = 6;
    [SerializeField] private Transform _unitPlace;

    private ReactiveCollection<IUnitProductionTask> _queue = new ReactiveCollection<IUnitProductionTask>();
    [Inject] private DiContainer _diContainer;

    private void Update()
    {
        if (_queue.Count == 0)
        {
            return;
        }

        var innerTask = (UnitProductionTask) _queue[0];
        innerTask.TimeLeft -= Time.deltaTime;
        if (innerTask.TimeLeft <= 0)
        {
            RemoveTaskAtIndex(0);
            CreateNewUnit(innerTask);
        }
    }

    public void Cancel(int index) => RemoveTaskAtIndex(index);

    private void RemoveTaskAtIndex(int index)
    {
        for (int i = index; i < _queue.Count - 1; i++)
        {
            _queue[i] = _queue[i + 1];
        }

        _queue.RemoveAt(_queue.Count - 1);
    }

    public override async Task ExecuteSpecificCommand(IProduceUnitCommand command)
    {
        if (_queue.Count < _maximumUnitsInQueue)
        {
            _queue.Add(new UnitProductionTask(command.ProductionTime, command.Icon, command.UnitPrefab,
                command.UnitName));
        }
    }

    private void CreateNewUnit(UnitProductionTask innerTask)
    {
        var instance = _diContainer.InstantiatePrefab(
            innerTask.UnitPrefab, transform.position,
            Quaternion.identity, _unitPlace);
        var queue = instance.GetComponent<ICommandsQueue>();
        var mainBuilding = GetComponent<MainBuilding>();
        queue.EnqueueCommand(new MoveCommand(mainBuilding.RallyPoint));
        var factionMember = instance.GetComponent<FactionMember>();
        factionMember.SetFaction(GetComponent<FactionMember>().FactionId);
    }
}
