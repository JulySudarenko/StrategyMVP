using Interfaces;
using UnityEngine;
using Zenject;

namespace CommandsRealization
{
    public class ProduceChomperCommandHeir : IProduceChomperCommand
    {
        [Inject(Id = "Chomper")] public string UnitName { get; }
        [Inject(Id = "Chomper")] public Sprite Icon { get; }
        [Inject(Id = "Chomper")] public float ProductionTime { get; }
        [Inject(Id = "Chomper")] public GameObject UnitPrefab { get; }
    }
}
