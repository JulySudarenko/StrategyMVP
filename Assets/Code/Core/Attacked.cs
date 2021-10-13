using Interfaces;
using UnityEngine;

public class Attacked : MonoBehaviour, IAttackable
{
    public float Health { get; }
    public float MaxHealth { get; }
}
