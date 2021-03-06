using Interfaces;
using UnityEngine;
using Zenject;

namespace CommandsRealization
{
    public class ProduceSpiderCommandHeir : IProduceSpiderCommand
    {
        [Inject(Id = "Spider")] public string UnitName { get; }
        [Inject(Id = "Spider")] public Sprite Icon { get; }
        [Inject(Id = "Spider")] public float ProductionTime { get; }
        [Inject(Id = "Spider")] public GameObject UnitPrefab { get; }
    }
}
