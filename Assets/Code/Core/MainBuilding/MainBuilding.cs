using Interfaces;
using UnityEngine;

public class MainBuilding : MonoBehaviour, ISelectable, IAttackable
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

    public void ReceiveDamage(int amount)
    {
        if (_health <= 0)
        {
            return;
        }

        _health -= amount;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
