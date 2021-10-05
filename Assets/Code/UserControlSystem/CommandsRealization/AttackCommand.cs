using Interfaces;
using UnityEngine;

namespace CommandsRealization
{
    public sealed class AttackCommand : IAttackCommand
    {
        public IAttackable Target { get; }
        public AttackCommand(IAttackable target)
        {
            Target = target;
            Debug.Log($"Attack constructor is work. Target is {target}");
        }
    }
}
