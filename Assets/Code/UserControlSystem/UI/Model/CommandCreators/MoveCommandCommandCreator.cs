﻿using System;
using CommandsRealization;
using UnityEngine;
using Interfaces;
using Utils;
using Zenject;

public class MoveCommandCommandCreator : CommandCreatorBase<IMoveCommand>
{
    [Inject] private AssetsContext _context;

    private Action<IMoveCommand> _creationCallback;

    [Inject]
    private void Init(Vector3Value groundClicks)
    {
        groundClicks.OnNewValue += ONNewValue;
    }

    private void ONNewValue(Vector3 groundClick)
    {
        _creationCallback?.Invoke(_context.Inject(new MoveCommand(groundClick)));
        _creationCallback = null;
    }

    protected override void classSpecificCommandCreation(Action<IMoveCommand> creationCallback)
    {
        _creationCallback = creationCallback;
    }

    public override void ProcessCancel()
    {
        base.ProcessCancel();

        _creationCallback = null;
    }
}
