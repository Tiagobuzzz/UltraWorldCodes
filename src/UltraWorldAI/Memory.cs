namespace UltraWorldAI;

/// <summary>
/// Represents a single remembered experience.
/// </summary>
public class Memory
{
    /// <summary>Short description of the event.</summary>
    public string Summary { get; set; } = string.Empty;

    /// <summary>Time when the memory occurred.</summary>
    public DateTime Date { get; set; }

    /// <summary>Importance of the memory on a 0-1 scale.</summary>
    public float Intensity { get; set; }

    /// <summary>Emotional valence associated with the memory.</summary>
    public float EmotionalCharge { get; set; }

    /// <summary>Optional label describing the dominant emotion.</summary>
    public string Emotion { get; set; } = string.Empty;

    /// <summary>Keywords that help relate this memory to other concepts.</summary>
    public List<string> Keywords { get; set; }

    /// <summary>Source of the memory (e.g., self or external).</summary>
    public string Source { get; set; } = string.Empty;

    public Memory()
    {
        Keywords = new List<string>();
    }
}
