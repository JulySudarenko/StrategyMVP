using System;
using CommandsRealization;
using Interfaces;
using Utils;
using Zenject;

public class ProduceSpiderCommandCreator : CommandCreatorBase<IProduceSpiderCommand>
{
    [Inject] private AssetsContext _context;
    [Inject] private DiContainer _diContainer;

    protected override void ClassSpecificCommandCreation(Action<IProduceSpiderCommand> creationCallback)
    {
        var produceUnitCommand = _context.Inject(new ProduceSpiderCommandHeir());
        _diContainer.Inject(produceUnitCommand);
        creationCallback?.Invoke(produceUnitCommand);
    }
}