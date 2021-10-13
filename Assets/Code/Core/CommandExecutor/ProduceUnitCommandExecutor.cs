﻿using Interfaces;
using UniRx;
using UnityEngine;

public class ProduceUnitCommandExecutor : CommandExecutorBase<IProduceUnitCommand>, IUnitProducer
{
    public IReadOnlyReactiveCollection<IUnitProductionTask> Queue => _queue;

    [SerializeField] private Transform _unitsParent;
    [SerializeField] private int _maximumUnitsInQueue = 6;
    [SerializeField] private Transform _unitPlace;
    [SerializeField] private float _distance = 10.0f;

    private ReactiveCollection<IUnitProductionTask> _queue = new ReactiveCollection<IUnitProductionTask>();

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
        int i;
        int length = _queue.Count - 1;
        for (i = index; i < length; i++)
        {
            _queue[i] = _queue[i + 1];
        }
        _queue.RemoveAt(length);
    }

    public override void ExecuteSpecificCommand(IProduceUnitCommand command)
    {
        _queue.Add(new UnitProductionTask(command.ProductionTime, command.Icon, command.UnitPrefab, command.UnitName));
    }

    private void CreateNewUnit(UnitProductionTask innerTask)
    {
        Instantiate(innerTask.UnitPrefab,
            CreateRandomPlaceForNewUnit(_unitsParent.position),
            Quaternion.identity, _unitPlace);
    }

    private Vector3 CreateRandomPlaceForNewUnit(Vector3 parentPlace)
    {
        var newX = Random.Range(parentPlace.x - _distance, parentPlace.x + _distance);
        var newZ = Random.Range(parentPlace.z - _distance, parentPlace.z + _distance);

        Vector3 placeForNewUnit = new Vector3(newX, 0, newZ);

        return placeForNewUnit;
    }
}
