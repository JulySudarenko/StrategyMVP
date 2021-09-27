using Interfaces;
using UnityEngine;
using Utils;

namespace CommandsRealization
{
    public sealed class ProduceUnitCommand : IProduceUnitCommand
    {
        public GameObject UnitPrefab => _unitPrefab;
        [InjectAsset("Chomper")] private GameObject _unitPrefab;
    }
}
