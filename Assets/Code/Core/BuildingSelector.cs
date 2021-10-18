using Interfaces;
using UnityEngine;

public class BuildingSelector : MonoBehaviour, ISelectable
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _health;
    [SerializeField] private Transform _transform;
    public Vector3 RallyPoint { get; set; }

    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    public Transform PositionPoint => _transform;
}
