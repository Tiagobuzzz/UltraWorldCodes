using System;
using System.Collections.Generic;

namespace UltraWorldAI.Politics;

/// <summary>
/// Very small democratic governance mechanic.
/// Citizens can propose and vote on laws.
/// </summary>
public class DemocraticGovernanceSystem
{
    private readonly Dictionary<string, int> _laws = new();
    private readonly List<string> _citizens = new();

    public void RegisterCitizen(string name) => _citizens.Add(name);

    public void ProposeLaw(string law)
    {
        if (!_laws.ContainsKey(law))
            _laws[law] = 0;
    }

    public void Vote(string law, string citizen, bool approve)
    {
        if (!_laws.ContainsKey(law) || !_citizens.Contains(citizen))
            return;
        _laws[law] += approve ? 1 : -1;
    }

    public IEnumerable<string> GetApprovedLaws()
    {
        foreach (var kv in _laws)
            if (kv.Value > 0)
                yield return kv.Key;
    }
}
