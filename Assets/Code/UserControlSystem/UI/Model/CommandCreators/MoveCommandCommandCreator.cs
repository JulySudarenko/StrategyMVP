using System;
using CommandsRealization;
using Interfaces;
using Utils;
using Zenject;

public class MoveCommandCommandCreator : CommandCreatorBase<IMoveCommand>
{
    [Inject] private AssetsContext _context;

    protected override void classSpecificCommandCreation(Action<IMoveCommand> creationCallback)
    {
        creationCallback?.Invoke(_context.Inject(new MoveCommand()));
    }
}
