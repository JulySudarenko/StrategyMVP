using UnityEngine;

namespace Interfaces
{
    public interface ISelectable : IHealthHolder, IIconHolder
    {
        Transform PositionPoint { get; }
    }
}
