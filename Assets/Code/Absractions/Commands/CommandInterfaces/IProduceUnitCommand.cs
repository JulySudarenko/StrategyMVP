using UnityEngine;

namespace Interfaces
{
    public interface IProduceUnitCommand : ICommand, IIconHolder
    {
        GameObject UnitPrefab { get; }
        float ProductionTime { get; }
        string UnitName { get; }
    }
    
    public interface IProduceChomperCommand : IProduceUnitCommand
    {

    }
    
    public interface IProduceSpiderCommand : IProduceUnitCommand
    {

    }
}
