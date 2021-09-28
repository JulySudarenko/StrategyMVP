using System;
using Interfaces;
using System.Collections.Generic;
using CommandsRealization;
using UnityEngine;
using Utils;
using View;

namespace UserControlSystem.UI.Presenter
{
    public sealed class CommandButtonsPresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectable;
        [SerializeField] private CommandButtonsView _view;
        [SerializeField] private AssetsContext _context;

        private ISelectable _currentSelectable;

        private void Start()
        {
            _selectable.OnSelected += ONSelected;
            ONSelected(_selectable.CurrentValue);

            _view.OnClick += ONButtonClick;
        }

        private void ONSelected(ISelectable selectable)
        {
            if (_currentSelectable == selectable)
            {
                return;
            }

            _currentSelectable = selectable;

            _view.Clear();
            if (selectable != null)
            {
                var commandExecutors = new List<ICommandExecutor>();
                commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
                _view.MakeLayout(commandExecutors);
            }
        }

        private void ONButtonClick(ICommandExecutor commandExecutor)
        {
            var command = commandExecutor.GetType();
            switch (command.Name)
            {
                case "Attack":
                     OnAttackClick(commandExecutor);
                    break;
                case "Move":
                    OnMoveClick(commandExecutor);
                    break;
                case "Patrol":
                    OnPatrolClick(commandExecutor);
                    break;
                case "Stop":
                    OnStopClick(commandExecutor);
                    break;
                case "ProduceUnit":
                    OnProduceUnitClick(commandExecutor);
                    break;
                default:
                    throw new ApplicationException($"{nameof(CommandButtonsPresenter)}.{nameof(ONButtonClick)}: " +
                                                   $"Unknown type of commands executor: {commandExecutor.GetType().FullName}!");
            }
        }

        private void OnProduceUnitClick(ICommandExecutor commandExecutor)
        {
            var command = commandExecutor as CommandExecutorBase<IProduceUnitCommand>;
            if (command != null)
            {
                command.ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommand()));
            }
        }
        
        private void OnAttackClick(ICommandExecutor commandExecutor)
        {
            var command = commandExecutor as CommandExecutorBase<IAttackCommand>;
            if (command != null)
            {
                command.ExecuteSpecificCommand(new AttackCommand());
            }
        }

        private void OnMoveClick(ICommandExecutor commandExecutor)
        {
            var command = commandExecutor as CommandExecutorBase<IMoveCommand>;
            if (command != null)
            {
                command.ExecuteSpecificCommand(new MoveCommand());
            }
        }

        private void OnPatrolClick(ICommandExecutor commandExecutor)
        {
            var command = commandExecutor as CommandExecutorBase<IPatrolCommand>;
            if (command != null)
            {
                command.ExecuteSpecificCommand(new PatrolCommand());
            }
        }

        private void OnStopClick(ICommandExecutor commandExecutor)
        {
            var command = commandExecutor as CommandExecutorBase<IStopCommand>;
            if (command != null)
            {
                command.ExecuteSpecificCommand(new StopCommand());
            }
        }
    }
}
