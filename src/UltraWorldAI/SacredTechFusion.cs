using System;
using System.Collections.Generic;

namespace UltraWorldAI.Fusion;

public class SacredTech
{
    public string TechName { get; set; } = string.Empty;
    public string EnchantedByMagic { get; set; } = string.Empty;
    public string DeifiedByReligion { get; set; } = string.Empty;
    public string SymbolicFunction { get; set; } = string.Empty;
    public string EffectOnWorld { get; set; } = string.Empty;
    public bool IsStable { get; set; }
}

public static class SacredTechFusion
{
    public static List<SacredTech> Fusions { get; } = new();

    public static SacredTech Fuse(string techName, string magicName, string religionName, string symbolicFunction)
    {
        var fusion = new SacredTech
        {
            TechName = techName,
            EnchantedByMagic = magicName,
            DeifiedByReligion = religionName,
            SymbolicFunction = symbolicFunction,
            IsStable = new Random().NextDouble() > 0.4,
            EffectOnWorld = $"Influencia todos que veem {techName} como símbolo de {symbolicFunction}"
        };

        Fusions.Add(fusion);
        return fusion;
    }

    public static string Describe(SacredTech s)
    {
        return $"⚙️🔮✝️ {s.TechName} fusionado com {s.EnchantedByMagic} e santificado por {s.DeifiedByReligion}\n" +
               $"Símbolo: {s.SymbolicFunction} | Efeito: {s.EffectOnWorld}\nEstável? {(s.IsStable ? "✅ Sim" : "⚠️ Instável")}";
    }

    public static string ListAll()
    {
        if (Fusions.Count == 0) return "Nenhuma fusão sagrada registrada.";
        return string.Join("\n\n", Fusions.ConvertAll(Describe));
    }
}
