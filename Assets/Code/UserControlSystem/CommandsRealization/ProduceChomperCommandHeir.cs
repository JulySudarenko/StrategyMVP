using UnityEngine;
using Zenject;

namespace CommandsRealization
{
    public class ProduceChomperCommandHeir : ProduceUnitCommand
    {
        [Inject(Id = "Chomper")] public string UnitName { get; }
        [Inject(Id = "Chomper")] public Sprite Icon { get; }
        [Inject(Id = "Chomper")] public float ProductionTime { get; }
        [Inject(Id = "Chomper")] public GameObject UnitPrefab { get; }
        public ProduceChomperCommandHeir()
        {
            Debug.Log("Created ProduceUnitCommandHeir");
        }
    }
}
