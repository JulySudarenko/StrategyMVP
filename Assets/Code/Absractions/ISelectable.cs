using UnityEngine;

namespace Interfaces
{
    public interface ISelectable
    {
        float Health { get; }
        float MaxHealth { get; }
        Sprite Icon { get; }
        Transform PositionPoint { get; }
    }
}
