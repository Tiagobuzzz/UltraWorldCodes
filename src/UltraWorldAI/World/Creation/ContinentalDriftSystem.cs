using System;
using System.Collections.Generic;

namespace UltraWorldAI.World.Creation;

public class Continent
{
    public string Name { get; set; } = string.Empty;
    public int PosX { get; set; }
    public int PosY { get; set; }
    public List<string> Territories { get; set; } = new();
}

public static class ContinentalDriftSystem
{
    public static List<Continent> Continents { get; } = new();

    public static void CreateContinent(string name, int x, int y, List<string> territories)
    {
        Continents.Add(new Continent
        {
            Name = name,
            PosX = x,
            PosY = y,
            Territories = territories
        });

        Console.WriteLine($"\uD83C\uDF0D Continente criado: {name} em ({x},{y})");
    }

    public static void Drift(string name, int dx, int dy)
    {
        var cont = Continents.Find(c => c.Name == name);
        if (cont != null)
        {
            cont.PosX += dx;
            cont.PosY += dy;
            Console.WriteLine($"\uD83C\uDF0A Deriva: {name} moveu para ({cont.PosX},{cont.PosY})");
        }
    }

    public static void PrintContinents()
    {
        foreach (var c in Continents)
            Console.WriteLine($"\n\uD83D\uDDFA\uFE0F {c.Name} | Posição: ({c.PosX},{c.PosY}) | Territórios: {string.Join(", ", c.Territories)}");
    }
}
