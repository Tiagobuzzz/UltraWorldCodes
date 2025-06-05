using System;
using System.Collections.Generic;

namespace UltraWorldAI.History;

public class TechEra
{
    public string Name { get; set; } = string.Empty;
    public string TriggerTech { get; set; } = string.Empty;
    public DateTime Start { get; set; }
    public List<string> Characteristics { get; set; } = new();
}

public static class TechTimelineSystem
{
    public static List<TechEra> Eras { get; } = new();

    public static void CreateEra(string tech, string style)
    {
        string name = $"Era de {tech}";
        var traits = new List<string>
        {
            $"Estilo dominante: {style}",
            $"Funda\u00e7\u00e3o: {tech}",
            "Transi\u00e7\u00e3o marcada por: ruptura ou ades\u00e3o tecnol\u00f3gica"
        };

        Eras.Add(new TechEra
        {
            Name = name,
            TriggerTech = tech,
            Start = DateTime.Now,
            Characteristics = traits
        });
    }

    public static string DescribeAll()
    {
        if (Eras.Count == 0) return "Nenhuma era tecnol\u00f3gica registrada ainda.";
        return string.Join("\n\n", Eras.ConvertAll(e =>
            $"\uD83D\uDCDC {e.Name}\nIniciada por: {e.TriggerTech} em {e.Start.ToShortDateString()}\n" +
            $"Caracter\u00edsticas: {string.Join(", ", e.Characteristics)}"));
    }
}
