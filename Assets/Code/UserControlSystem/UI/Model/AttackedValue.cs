using System;
using Interfaces;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(AttackedValue), menuName = "Strategy Game/" + nameof(AttackedValue), order = 0)]
public class AttackedValue  : ScriptableObject
{
    public IAttacked CurrentValue { get; private set; }
    public Action<IAttacked> OnAttack;

    public void SetValue(IAttacked value)
    {
        CurrentValue = value;
        OnAttack?.Invoke(value);
    }
}
