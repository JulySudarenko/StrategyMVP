using Interfaces;
using UnityEngine;

public class ProduceUnit : CommandExecutorBase<IProduceUnitCommand>
{
    [SerializeField] private Transform _unitsParent;
    [SerializeField] private Transform _unitPlace;
    [SerializeField] private float _distance = 10.0f;

    public override void ExecuteSpecificCommand(IProduceUnitCommand command)
        => Instantiate(command.UnitPrefab,
            CreateRandomPlaceForNewUnit(_unitsParent.position),
            Quaternion.identity, _unitPlace);

    private Vector3 CreateRandomPlaceForNewUnit(Vector3 parentPlace)
    {
        var newX = Random.Range(parentPlace.x - _distance, parentPlace.x + _distance);
        var newZ = Random.Range(parentPlace.z - _distance, parentPlace.z + _distance);

        Vector3 placeForNewUnit = new Vector3(newX, 0, newZ);

        return placeForNewUnit;
    }
}
