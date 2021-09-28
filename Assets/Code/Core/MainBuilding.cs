using Interfaces;
using UnityEngine;

public class MainBuilding : CommandExecutorBase<IProduceUnitCommand>, ISelectable
{
    [SerializeField] private Transform _unitsParent;
    [SerializeField] private Sprite _icon;
    [SerializeField] private float _maxHealth = 1000;
    [SerializeField] private float _distance = 10.0f;

    private float _health = 1000;

    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;

    public override void ExecuteSpecificCommand(IProduceUnitCommand command)
        => Instantiate(command.UnitPrefab,
            CreateRandomPlaceForNewUnit(_unitsParent.position),
            Quaternion.identity, _unitsParent);

    private Vector3 CreateRandomPlaceForNewUnit(Vector3 parentPlace)
    {
        var newX = Random.Range(parentPlace.x - _distance, parentPlace.x + _distance);
        var newZ = Random.Range(parentPlace.z - _distance, parentPlace.z + _distance);

        Vector3 placeForNewUnit = new Vector3(newX, 0, newZ);

        return placeForNewUnit;
    }
}