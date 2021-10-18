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
        if (_currentSelectable == selectable)
        {
            return;
        }
        if (_currentSelectable != null)
        {
            _model.OnSelectionChanged();
        }
        _currentSelectable = selectable;

        _view.Clear();
        if (selectable != null)
        {
            var commandExecutors = new List<ICommandExecutor>();
            commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
            var queue = (selectable as Component).GetComponentInParent<ICommandsQueue>();
            _view.MakeLayout(commandExecutors, queue);
        }
    }
}