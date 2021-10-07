using System;
using Interfaces;
using UnityEngine;
using Utils;
using Zenject;

public class StopCommandCommandCreator : CommandCreatorBase<IStopCommand>
{
    [Inject] private SelectableValue _selectable;

    protected override void ClassSpecificCommandCreation(Action<IStopCommand> creationCallback)
    {
        Debug.Log($"Command stop in point {_selectable.CurrentValue.PositionPoint.position}");
    }
}
