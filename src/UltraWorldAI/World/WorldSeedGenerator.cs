using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.World;

public class WorldRegion
{
    public string Name { get; set; } = string.Empty;
    public string Symbol { get; set; } = string.Empty;
    public string Climate { get; set; } = string.Empty;
    public string Biome { get; set; } = string.Empty;
    public string ElementalAffinity { get; set; } = string.Empty;
    public int Richness { get; set; }
    public int MagicLevel { get; set; }
    public int TechInfluence { get; set; }
}

public static class WorldSeedGenerator
{
    public static List<WorldRegion> Regions { get; } = new();

    public static void Generate(int count)
    {
        string[] names = { "Orvak", "Ylendra", "Tiron", "Maraqu", "Koraith", "Valuun", "Luz de Vyr", "Noctovar" };
        string[] biomes = { "Deserto Vazio", "Floresta Sombria", "Montanha Cantante", "Planície Viva", "Manguezal do Esquecimento" };
        string[] climates = { "Árido", "Úmido", "Frio", "Instável", "Simbólico" };
        string[] affinities = { "Fogo", "Água", "Sombra", "Luz", "Memória", "Sangue", "Vento", "Silêncio" };

        var rand = new Random();
        for (int i = 0; i < count; i++)
        {
            var region = new WorldRegion
            {
                Name = names[rand.Next(names.Length)] + "-" + rand.Next(1000, 9999),
                Symbol = affinities[rand.Next(affinities.Length)],
                Climate = climates[rand.Next(climates.Length)],
                Biome = biomes[rand.Next(biomes.Length)],
                ElementalAffinity = affinities[rand.Next(affinities.Length)],
                Richness = rand.Next(40, 100),
                MagicLevel = rand.Next(0, 100),
                TechInfluence = rand.Next(0, 100)
            };

            Regions.Add(region);
        }
    }

    public static string ListAll()
    {
        if (Regions.Count == 0) return "Nenhuma região gerada.";
        return string.Join("\n\n", Regions.ConvertAll(r =>
            $"\uD83C\uDF0D {r.Name} ({r.Biome})\nClima: {r.Climate} | Símbolo: {r.Symbol} | Afinidade: {r.ElementalAffinity}\nRiqueza: {r.Richness} | Magia: {r.MagicLevel} | Influência Tecnológica: {r.TechInfluence}"));
    }

    public static string GetNearbyRegion(string current)
    {
        if (Regions.Count == 0) return current;
        var region = Regions.FirstOrDefault(r => r.Name == current);
        var candidates = Regions.Where(r => r.Name != current && r.Biome == region?.Biome).ToList();
        if (candidates.Count == 0)
            candidates = Regions.Where(r => r.Name != current).ToList();
        if (candidates.Count == 0) return current;
        return candidates[new Random().Next(candidates.Count)].Name;
    }
}
