using System.Collections.Generic;

namespace UltraWorldAI.Territory;

public static class ConstructionEngine
{
    public class Structure
    {
        public string Type { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string SymbolicPurpose { get; set; } = string.Empty;
        public float EmotionalCharge { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
    }

    public static List<Structure> BuiltStructures { get; } = new();

    public static void BuildStructure(Mind mind, SpatialIdentity location, string purpose)
    {
        string type = ClassifyStructure(purpose);
        string dominantEmotion = mind.Emotions.GetDominantEmotion();
        float emotion = mind.Emotions.GetEmotion(dominantEmotion);

        var structure = new Structure
        {
            Type = type,
            Region = location.RegionName,
            SymbolicPurpose = purpose,
            EmotionalCharge = emotion,
            CreatedBy = mind.PersonReference.Name
        };

        BuiltStructures.Add(structure);

        mind.Memory.AddMemory($"Construiu {type} em {location.RegionName}");
        mind.IdeaEngine.GenerateIdea($"Construção de {type}", new() { location.RegionName }, emotion, 0.8f);

        if (emotion > 0.7f)
            SacredSpace.SanctifyRegion(location.RegionName);
    }

    public static void UpgradeStructure(string region, string type)
    {
        var s = BuiltStructures.Find(b => b.Region == region && b.Type == type);
        if (s != null)
            s.SymbolicPurpose += " (Aprimorado)";
    }

    private static string ClassifyStructure(string purpose)
    {
        if (purpose.Contains("fé") || purpose.Contains("deus")) return "Templo";
        if (purpose.Contains("memória") || purpose.Contains("história")) return "Monumento";
        if (purpose.Contains("proteção")) return "Muro";
        if (purpose.Contains("amor") || purpose.Contains("paz")) return "Casa";
        return "Altar Ritual";
    }

    public static string DescribeAll()
    {
        if (BuiltStructures.Count == 0)
            return "Nada foi construído ainda.";

        var desc = new List<string>();
        foreach (var s in BuiltStructures)
        {
            desc.Add($"[{s.Region}] - {s.Type} por {s.CreatedBy} (Motivo: {s.SymbolicPurpose})");
        }
        return string.Join("\n", desc);
    }
}

