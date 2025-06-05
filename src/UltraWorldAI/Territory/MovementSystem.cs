using System;

namespace UltraWorldAI.Territory;

public static class MovementSystem
{
    private static readonly Random _random = new();

    public static void Move(Person person, float dx, float dy)
    {
        var position = person.Location;
        float newX = position.X + dx;
        float newY = position.Y + dy;

        var region = ResolveRegion(newX, newY);
        position.MoveTo(region.Name, newX, newY, region.Sacred, region.Hostile);

        person.Mind.Memory.AddMemory($"Visitou {position.RegionName}");
        person.Mind.IdeaEngine.GenerateIdea(
            $"Movimento até {position.RegionName}",
            new() { position.RegionName },
            0.2f + (float)_random.NextDouble() * 0.4f,
            0.3f + (float)_random.NextDouble() * 0.4f);

        if (position.IsHostile)
        {
            person.Mind.Stress.AddStress(0.1f);
            person.Mind.IdeaEngine.GenerateIdea(
                "Região Hostil",
                new() { position.RegionName },
                0.7f,
                0.8f);
        }

        if (position.IsSacredGround)
        {
            person.Mind.IdeaEngine.GenerateIdea(
                "Presença de poder simbólico",
                new() { position.RegionName },
                0.9f,
                0.9f);
        }
    }

    private static (string Name, bool Sacred, bool Hostile) ResolveRegion(float x, float y)
    {
        if (x < 0 && y < 0) return ("Ruínas do Sul", false, true);
        if (x > 0 && y > 0) return ("Planícies do Norte", false, false);
        if (x < 0 && y > 0) return ("Vale dos Ventos", false, false);
        return ("Bosque Fragmentado", true, false);
    }
}
