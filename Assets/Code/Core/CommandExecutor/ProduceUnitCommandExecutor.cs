﻿using System.Threading.Tasks;
using Interfaces;
using UniRx;
using UnityEngine;
using Zenject;

public class ProduceUnitCommandExecutor : CommandExecutorBase<IProduceUnitCommand>, IUnitProducer
{
    public IReadOnlyReactiveCollection<IUnitProductionTask> Queue => _queue;

    [SerializeField] private Transform _unitsParent;
    [SerializeField] private int _maximumUnitsInQueue = 6;
    [SerializeField] private Transform _unitPlace;
    [SerializeField] private float _distance = 10.0f;

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
            removeTaskAtIndex(0);
            CreateNewUnit(innerTask);
        }
    }

    public void Cancel(int index) => removeTaskAtIndex(index);

    private void removeTaskAtIndex(int index)
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
    //
    // private Vector3 CreateRandomPlaceForNewUnit(Vector3 parentPlace)
    // {
    //     var newX = Random.Range(parentPlace.x - _distance, parentPlace.x + _distance);
    //     var newZ = Random.Range(parentPlace.z - _distance, parentPlace.z + _distance);
    //
    //     Vector3 placeForNewUnit = new Vector3(newX, 0, newZ);
    //
    //     return placeForNewUnit;
    // }
}
