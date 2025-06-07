using System;
using System.Collections.Generic;

namespace UltraWorldAI.Module15;

public class PerformanceGroup
{
    public string Name = string.Empty;
    public List<string> Members = new();
    public string Form = string.Empty; // "Coro cerimonial", "Dueto profético", "Encenação pública"
    public string Purpose = string.Empty; // "Invocar", "Comover", "Educar", "Celebrar"
}

public static class PerformanceSocialSystem
{
    public static List<PerformanceGroup> Groups { get; } = new();

    public static void CreatePerformance(string name, List<string> members, string form, string purpose)
    {
        Groups.Add(new PerformanceGroup
        {
            Name = name,
            Members = members,
            Form = form,
            Purpose = purpose
        });

        Console.WriteLine($"\uD83C\uDFA4 Performance criada: {name} | Forma: {form} | Finalidade: {purpose}");
    }
}
