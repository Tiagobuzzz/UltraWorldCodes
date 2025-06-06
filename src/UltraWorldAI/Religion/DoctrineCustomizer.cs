using System.Collections.Generic;

namespace UltraWorldAI.Religion;

/// <summary>
/// Utility to customize religious doctrines after creation.
/// </summary>
public static class DoctrineCustomizer
{
    public static void Customize(Doctrine doctrine, IEnumerable<string>? rules = null, string? method = null, bool? mutable = null)
    {
        if (rules != null)
        {
            foreach (var r in rules)
            {
                if (!doctrine.SacredRules.Contains(r))
                    doctrine.SacredRules.Add(r);
            }
        }
        if (method != null)
            doctrine.TransmissionMethod = method;
        if (mutable.HasValue)
            doctrine.IsMutable = mutable.Value;
    }
}
