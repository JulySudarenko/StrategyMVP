using System;
using UnityEngine;

namespace Interfaces
{
    public interface ISelectable : IHealthHolder
    {
        Sprite Icon { get; }
        Transform PositionPoint { get; }
    }
}
