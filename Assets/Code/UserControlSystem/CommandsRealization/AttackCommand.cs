using Interfaces;
using UnityEngine;

namespace CommandsRealization
{
    public sealed class AttackCommand : IAttackCommand
    {
        public AttackCommand()
        {
            Debug.Log("Attack constructor is work");
        }
    }
}
