using System;
using CommandsRealization;
using Interfaces;
using Utils;
using Zenject;

public class ProduceChomperCommandCreator : CommandCreatorBase<IProduceChomperCommand>
{
    [Inject] private AssetsContext _context;
    [Inject] private DiContainer _diContainer;

    protected override void ClassSpecificCommandCreation(Action<IProduceChomperCommand> creationCallback)
    {
        var produceUnitCommand = _context.Inject(new ProduceChomperCommandHeir());
        _diContainer.Inject(produceUnitCommand);
        creationCallback?.Invoke(produceUnitCommand);
    }
}
