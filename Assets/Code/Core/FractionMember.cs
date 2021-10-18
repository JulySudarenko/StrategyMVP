using System.Collections.Generic;
using System.Linq;
using Interfaces;
using UnityEngine;

public class FractionMember : MonoBehaviour, IFractionMember
{
    private static Dictionary<int, List<int>> _membersCount = new Dictionary<int, List<int>>();
    public int FactionId => _factionId;
    [SerializeField] private int _factionId;

    public void SetFaction(int factionId)
    {
        _factionId = factionId;
        Register();
    }
    
    public static int FactionsCount
    {
        get
        {
            lock (_membersCount)
            {
                return _membersCount.Count;
            }
        }
    }

    public static int GetWinner()
    {
        lock (_membersCount)
        {
            return _membersCount.Keys.First();
        }
    }

    private void Awake()
    {
        if (_factionId != 0)
        {
            Register();
        }
    }

    private void OnDestroy()
    {
        UnRegister();
    }

    private void Register()
    {
        lock (_membersCount)
        {
            if (!_membersCount.ContainsKey(_factionId))
            {
                _membersCount.Add(_factionId, new List<int>());
            }

            if (!_membersCount[_factionId].Contains(GetInstanceID()))
            {
                _membersCount[_factionId].Add(GetInstanceID());
            }
        }
    }

    private void UnRegister()
    {
        lock (_membersCount)
        {
            if (_membersCount[_factionId].Contains(GetInstanceID()))
            {
                _membersCount[_factionId].Remove(GetInstanceID());
            }

            if (_membersCount[_factionId].Count == 0)
            {
                _membersCount.Remove(_factionId);
            }
        }
    }
}
