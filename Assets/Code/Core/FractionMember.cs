using Interfaces;
using UnityEngine;

public class FractionMember : MonoBehaviour, IFractionMember
{
    public int FactionId => _factionId;
    [SerializeField] private int _factionId;

    public void SetFaction(int factionId)
    {
        _factionId = factionId;
    }
}
