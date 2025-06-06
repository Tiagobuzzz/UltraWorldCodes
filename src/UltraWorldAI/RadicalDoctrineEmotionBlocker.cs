using System.Collections.Generic;
using ReligionDoctrine = UltraWorldAI.Religion.Doctrine;

namespace UltraWorldAI;

/// <summary>
/// Blocks certain emotions when radical doctrines are active.
/// </summary>
public class RadicalDoctrineEmotionBlocker
{
    private readonly HashSet<string> _blockedEmotions = new();

    public void ApplyDoctrine(ReligionDoctrine doctrine, IEnumerable<string> emotions)
    {
        if (doctrine.KnownHeresies.Count > 5)
        {
            foreach (var e in emotions)
                _blockedEmotions.Add(e);
        }
    }

    public bool IsBlocked(string emotion) => _blockedEmotions.Contains(emotion);
}
