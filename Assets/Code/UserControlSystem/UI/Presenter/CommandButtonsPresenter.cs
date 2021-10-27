using System;
using Interfaces;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using View;
using Zenject;
using Component = UnityEngine.Component;

public class CommandButtonsPresenter : MonoBehaviour
{
    [SerializeField] private CommandButtonsView _view;
    [Inject] private CommandButtonsModel _model;
    [Inject] private IObservable<ISelectable> _selectableValue;

    private ISelectable _currentSelectable;

    private ICommandExecutor<IMoveCommand> _mover;
    private ICommandsQueue _queue;
    private ISelectable _selectable;

    private void Start()
    {
        _view.OnClick += _model.OnCommandButtonClicked;
        _model.OnCommandSent += _view.UnblockAllInteractions;
        _model.OnCommandCancel += _view.UnblockAllInteractions;
        _model.OnCommandAccepted += _view.BlockInteractions;

        _selectableValue.Subscribe(OnSelected);
    }

    private void OnSelected(ISelectable selectable)
    {
        _selectable = selectable;
        if (_currentSelectable == _selectable)
        {
            return;
        }

        if (_currentSelectable != null)
        {
            _model.OnSelectionChanged();
        }

        _currentSelectable = _selectable;

        _view.Clear();
        if (_selectable != null)
        {
            var commandExecutors = new List<ICommandExecutor>();
            commandExecutors.AddRange((_selectable as Component).GetComponentsInParent<ICommandExecutor>());
            _queue = (_selectable as Component).GetComponentInParent<ICommandsQueue>();
            _view.MakeLayout(commandExecutors, _queue);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _mover = (_selectable as Component).GetComponentInParent<ICommandExecutor<IMoveCommand>>();
            if (_mover != null)
            {
                _model.OnCommandButtonClicked(_mover, _queue);
            }
        }
    }
}
