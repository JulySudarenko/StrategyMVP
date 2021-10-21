using Interfaces;
using UnityEngine;
using Utils;
using Zenject;

namespace CommandsRealization
{
    public class ProduceUnitCommand : IProduceUnitCommand
    {
        public Sprite Icon { get; }
        public GameObject UnitPrefab { get; }
        public float ProductionTime { get; }
        public string UnitName { get; }
    }
}