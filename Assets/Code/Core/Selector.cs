using Interfaces;
using UnityEngine;

public class Selector : MonoBehaviour, ISelectable
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _health;
    [SerializeField] private Transform _transform;

    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    public Transform PositionPoint => _transform;
}
