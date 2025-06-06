using System.Collections.Generic;
using UltraWorldAI;

namespace UltraWorldAI.ModScripting;

/// <summary>
/// Minimal context passed to mod scripts.
/// </summary>
public class ModContext
{
    public List<Person> People { get; } = new();
}

