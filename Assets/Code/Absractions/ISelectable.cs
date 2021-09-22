using UnityEngine;

namespace DefaultNamespace
{
    public interface ISelectable
    {
        float Health { get; }
        float MaxHealth { get; }
        Sprite Icon { get; }
    }
}
