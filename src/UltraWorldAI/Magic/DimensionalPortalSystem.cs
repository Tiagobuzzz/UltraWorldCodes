using System;
using System.Collections.Generic;

namespace UltraWorldAI.Magic;

public class Portal
{
    public string Location = string.Empty;
    public string DestinationRealm = string.Empty; // "Plano das Sombras", "Coração do Tempo", etc.
    public bool IsStable;
}

public class Realm
{
    public string Name = string.Empty;
    public string Rule = string.Empty; // "Sem tempo", "Somente pensamentos", "Gravidade reversa"
}

public static class DimensionalPortalSystem
{
    public static List<Portal> Portals { get; } = new();
    public static List<Realm> Realms { get; } = new();

    public static void CreateRealm(string name, string rule)
    {
        Realms.Add(new Realm { Name = name, Rule = rule });
        Console.WriteLine($"\uD83C\uDF0C Reino criado: {name} | Regra: {rule}");
    }

    public static void CreatePortal(string location, string realm, bool stable)
    {
        Portals.Add(new Portal { Location = location, DestinationRealm = realm, IsStable = stable });
        Console.WriteLine($"\uD83C\uDF00 Portal em {location} \u2192 {realm} | Est\u00E1vel: {stable}");
    }
}
