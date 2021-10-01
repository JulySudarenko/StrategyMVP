using Interfaces;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(AttackedValue), menuName = "Strategy Game/" + nameof(AttackedValue), order = 0)]
public class AttackedValue  : ScriptableModelBase<IAttacked>
{
}
