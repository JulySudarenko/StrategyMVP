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
            // var command = commandExecutor.GetType();
            // Debug.Log(command.ToString());
            // switch (Type)
            // {
            //     case Attack:
            //         OnAttackClick(commandExecutor);
            //         break;
            //     
            //     default:
            //         throw new ApplicationException($"{nameof(CommandButtonsPresenter)}.{nameof(ONButtonClick)}: " +
            //                                        $"Unknown type of commands executor: {commandExecutor.GetType().FullName}!");
            //         break;
            //         
            // }
            //
            // OnProduceUnitClick(commandExecutor);

        }

        private void OnProduceUnitClick(ICommandExecutor commandExecutor)
        {


            var unitProducer = commandExecutor as CommandExecutorBase<IProduceUnitCommand>;
            if (unitProducer != null)
            {
                unitProducer.ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommand()));
                return;
            }
            throw new ApplicationException($"{nameof(CommandButtonsPresenter)}.{nameof(ONButtonClick)}: " +
                                           $"Unknown type of commands executor: {commandExecutor.GetType().FullName}!");
        }
        
        private void OnAttackClick(ICommandExecutor commandExecutor)
        {
            var unitAttack = commandExecutor as CommandExecutorBase<IAttackCommand>;
            if (unitAttack != null)
            {
                unitAttack.ExecuteSpecificCommand(new AttackCommand());
            }
            throw new ApplicationException($"{nameof(CommandButtonsPresenter)}.{nameof(ONButtonClick)}: " +
                                           $"Unknown type of commands executor: {commandExecutor.GetType().FullName}!");
        }
    }
}
