using System;
using System.Collections.Generic;

namespace UltraWorldAI.DivineWorld;

public class DivineEntity
{
    public string Name { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string Domain { get; set; } = string.Empty;
    public string Memory { get; set; } = string.Empty;
}

public class AlternatePlane
{
    public string Name { get; set; } = string.Empty;
    public string Nature { get; set; } = string.Empty;
    public List<string> Laws { get; set; } = new();
}

public static class CosmologyCreationSystem
{
    public static List<DivineEntity> Entities { get; } = new();
    public static List<AlternatePlane> Planes { get; } = new();

    public static void CreateEntity(string name, string role, string domain, string memory)
    {
        Entities.Add(new DivineEntity
        {
            Name = name,
            Role = role,
            Domain = domain,
            Memory = memory
        });
        Console.WriteLine($"\u272F Nova entidade criada: {name}, dom\u00ednio: {domain}, papel: {role}");
    }

    public static void CreatePlane(string name, string nature, List<string> laws)
    {
        Planes.Add(new AlternatePlane
        {
            Name = name,
            Nature = nature,
            Laws = laws
        });
        Console.WriteLine($"\uD83C\uDF0C Plano alternativo criado: {name} ({nature}) com leis: {string.Join(", ", laws)}");
    }
}

