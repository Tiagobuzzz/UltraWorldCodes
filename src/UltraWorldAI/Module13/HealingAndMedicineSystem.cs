using System;
using System.Collections.Generic;

namespace UltraWorldAI.Module13;

public class HealingMethod
{
    public string Culture = string.Empty;
    public string Type = string.Empty; // "Herborismo", "Ritual", "Cirurgia", "Po\u00e7\u00e3o"
    public string EffectiveFor = string.Empty; // "Infec\u00e7\u00f5es", "Feridas", "Cegueira"
    public float SuccessRate;
}

public static class HealingAndMedicineSystem
{
    public static List<HealingMethod> Methods { get; } = new();

    public static void AddMethod(string culture, string type, string target, float rate)
    {
        Methods.Add(new HealingMethod
        {
            Culture = culture,
            Type = type,
            EffectiveFor = target,
            SuccessRate = rate
        });

        Console.WriteLine($"\uD83C\uDF33 M\u00e9todo de cura: {type} ({culture}) | Eficaz para: {target} | Sucesso: {rate * 100}%");
    }

    public static void PrintMethods()
    {
        foreach (var m in Methods)
            Console.WriteLine($"\uD83C\uDF31 {m.Culture} | {m.Type} \u2192 {m.EffectiveFor} ({m.SuccessRate * 100}%)");
    }
}
