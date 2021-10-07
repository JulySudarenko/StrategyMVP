using System;
using CommandsRealization;
using Interfaces;
using Utils;
using Zenject;

public class AttackCommandCommandCreator : CommandCreatorBase<IAttackCommand>
{
    [Inject] private AssetsContext _context;

    private Action<IAttackCommand> _creationCallback;

    [Inject]
    private void Init(AttackedValue groundClicks)
    {
        groundClicks.OnNewValue += OnNewValue;
    }

    private void OnNewValue(IAttacked attacked)
    {
        _creationCallback?.Invoke(_context.Inject(new AttackCommand(attacked)));
        _creationCallback = null;
    }

    protected override void ClassSpecificCommandCreation(Action<IAttackCommand> creationCallback)
    {
        _creationCallback = creationCallback;
    }
    
    public override void ProcessCancel()
    {
        base.ProcessCancel();

        _creationCallback = null;
    }
}
