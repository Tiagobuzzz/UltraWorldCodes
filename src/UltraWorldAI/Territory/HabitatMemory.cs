using System.Collections.Generic;

namespace UltraWorldAI.Territory;

public class HabitatMemory
{
    public class MemoryTag
    {
        public string RegionName { get; set; } = string.Empty;
        public string Environment { get; set; } = string.Empty;
        public string Emotion { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public float Intensity { get; set; }
    }

    public List<MemoryTag> TaggedPlaces { get; } = new();

    public void TagPlace(string region, string emotion, string description, float intensity, string environment = "neutral")
    {
        var existing = TaggedPlaces.Find(p => p.RegionName == region && p.Environment == environment);
        if (existing == null)
        {
            TaggedPlaces.Add(new MemoryTag
            {
                RegionName = region,
                Environment = environment,
                Emotion = emotion,
                Description = description,
                Intensity = intensity
            });
        }
        else
        {
            existing.Intensity = (existing.Intensity + intensity) / 2f;
            existing.Description = $"{existing.Description} | {description}";
        }
    }

    public List<MemoryTag> GetStrongestMemories(float threshold = 0.5f, string? environment = null)
    {
        return TaggedPlaces.FindAll(p => p.Intensity >= threshold &&
            (environment == null || p.Environment == environment));
    }

    public string Describe()
    {
        if (TaggedPlaces.Count == 0)
            return "Sem memórias territoriais.";

        var list = new List<string>();
        foreach (var m in TaggedPlaces)
        {
            list.Add($"[{m.RegionName}]({m.Environment}) sentiu '{m.Emotion}' - {m.Description} (Intensidade {m.Intensity})");
        }
        return string.Join("\n", list);
    }
}
