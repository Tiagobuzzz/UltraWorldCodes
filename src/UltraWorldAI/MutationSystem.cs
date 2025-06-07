namespace UltraWorldAI;

public static class MutationSystem
{
    public static void MutateCulture(string culture, string description)
    {
        CulturalMutationSystem.ApplyMutation(culture, description, "devo\u00e7\u00e3o divina", "Mudan\u00e7a cultural");
    }
}
