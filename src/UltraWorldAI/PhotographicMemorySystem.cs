using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI;

/// <summary>
/// Memory system that does not forget experiences and preserves intensity.
/// </summary>
public class PhotographicMemorySystem : MemorySystem
{
    /// <inheritdoc />
    public override void AddMemory(string summary, float intensity = 0.5f, float emotionalCharge = 0.0f,
        List<string>? keywords = null, string source = "self", string emotion = "", bool isFalse = false)
    {
        Memories.Add(new Memory
        {
            Summary = summary,
            Date = DateTime.Now,
            Intensity = Math.Clamp(intensity, 0f, 1f),
            EmotionalCharge = Math.Clamp(emotionalCharge, -1f, 1f),
            Keywords = keywords ?? new List<string>(),
            Source = source,
            Emotion = emotion,
            IsFalse = isFalse
        });
        Memories.Sort((a, b) => b.Date.CompareTo(a.Date));
    }

    /// <inheritdoc />
    public override void UpdateMemoryDecay()
    {
        // Photographic memory retains full intensity and never discards memories.
    }
}
