using System;
using System.Collections.Generic;

namespace UltraWorldAI.Relationships;

public class EmotionalUnion
{
    public string PartnerA = string.Empty;
    public string PartnerB = string.Empty;
    public string UnionType = string.Empty; // "Casamento cerimonial", "Pacto de sangue", "União de almas"
    public List<string> Vows = new(); // "Nunca partir", "Gerar filhos na lua cheia"
    public bool InheritedEmotion;
}

public static class EmotionalMarriageSystem
{
    public static List<EmotionalUnion> Unions { get; } = new();

    public static void FormUnion(string a, string b, string type, List<string> vows, bool inherited)
    {
        Unions.Add(new EmotionalUnion
        {
            PartnerA = a,
            PartnerB = b,
            UnionType = type,
            Vows = vows,
            InheritedEmotion = inherited
        });

        Console.WriteLine($"\uD83D\uDC8D União entre {a} e {b} | Tipo: {type} | Votos: {string.Join(", ", vows)}");
    }
}
