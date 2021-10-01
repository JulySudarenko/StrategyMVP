﻿using System;
using CommandsRealization;
using Interfaces;
using UnityEngine;
using Utils;
using Zenject;

public class PatrolCommandCommandCreator : CommandCreatorBase<IPatrolCommand>
{
    [Inject] private AssetsContext _context;

    private Action<IPatrolCommand> _creationCallback;

    [Inject]
    private void Init(Vector3Value groundClicks)
    {
        groundClicks.OnNewValue += ONNewValue;
    }

    private void ONNewValue(Vector3 groundClick)
    {
        _creationCallback?.Invoke(_context.Inject(new PatrolCommand(groundClick, groundClick)));
        _creationCallback = null;
    }

    protected override void ClassSpecificCommandCreation(Action<IPatrolCommand> creationCallback)
    {
        _creationCallback = creationCallback;
    }

    public override void ProcessCancel()
    {
        base.ProcessCancel();

        _creationCallback = null;
    }
}
