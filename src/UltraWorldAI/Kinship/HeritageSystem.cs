namespace UltraWorldAI.Kinship;

public class HeritageProfile
{
    public string Name = string.Empty;
    public Dictionary<string, float> GeneticTraits = new();
    public List<string> CulturalTraits = new();
    public List<string> MysticalMarks = new();
}

public static class HeritageSystem
{
    public static Dictionary<string, HeritageProfile> Profiles = new();

    public static void CreateProfile(string name, Dictionary<string, float> genes, List<string> culture, List<string> mystic)
    {
        Profiles[name] = new HeritageProfile
        {
            Name = name,
            GeneticTraits = genes,
            CulturalTraits = culture,
            MysticalMarks = mystic
        };
        Console.WriteLine($"🧬 Perfil hereditário: {name} | Genes: {genes.Count} | Cultura: {culture.Count} | Místico: {mystic.Count}");
    }
}
