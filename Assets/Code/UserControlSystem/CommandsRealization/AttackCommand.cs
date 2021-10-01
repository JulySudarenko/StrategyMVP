using Interfaces;
using UnityEngine;

namespace CommandsRealization
{
    public sealed class AttackCommand : IAttackCommand
    {
        public IAttacked Target { get; }
        public AttackCommand(IAttacked target)
        {
            Target = target;
            Debug.Log($"Attack constructor is work. Target is {target}");
        }
    }
}
