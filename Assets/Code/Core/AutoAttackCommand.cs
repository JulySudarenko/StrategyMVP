using Interfaces;
using UnityEngine;

public sealed class AutoAttackCommand : IAttackCommand
{
    public IAttackable Target { get; }

    public AutoAttackCommand(IAttackable target)
    {
        Target = target;
        Debug.Log($"Unit can attack {target}");
    }
}