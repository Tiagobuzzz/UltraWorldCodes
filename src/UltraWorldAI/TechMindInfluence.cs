using System.Collections.Generic;

namespace UltraWorldAI.Mental;

public static class TechMindInfluence
{
    public static Dictionary<string, List<string>> CognitiveTraits { get; } = new();

    public static void ApplyTechInfluence(string brainID, string style)
    {
        List<string> traits = style switch
        {
            string s when s.Contains("Tecnocracia") => new() { "l\u00f3gica fria", "efici\u00eancia", "an\u00e1lise cont\u00ednua" },
            string s when s.Contains("Magocracia") => new() { "intui\u00e7\u00e3o simb\u00f3lica", "ciclos lunares", "mem\u00f3ria ritual" },
            string s when s.Contains("Feudalismo") => new() { "honra", "hierarquia", "resposta direta" },
            string s when s.Contains("Rede") => new() { "colabora\u00e7\u00e3o", "autonomia", "resolu\u00e7\u00e3o emergente" },
            _ => new() { "ancestralidade", "preserva\u00e7\u00e3o", "sil\u00eancio emocional" }
        };

        CognitiveTraits[brainID] = traits;
    }

    public static string Describe(string brainID)
    {
        return CognitiveTraits.ContainsKey(brainID)
            ? $"\uD83E\uDD16 Tra\u00e7os mentais de {brainID}: {string.Join(", ", CognitiveTraits[brainID])}"
            : "Nenhuma influ\u00eancia tecnol\u00f3gica aplicada ainda.";
    }
}
