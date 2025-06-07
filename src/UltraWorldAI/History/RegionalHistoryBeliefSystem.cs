using System;
using System.Collections.Generic;

namespace UltraWorldAI.History;

public static class RegionalHistoryBeliefSystem
{
    private static readonly Dictionary<Person, string> Birthplaces = new();
    private static readonly Dictionary<string, string> OfficialVersions = new();
    private static readonly Dictionary<string, Dictionary<string, string>> RegionalVersions = new();

    public static void RegisterBirthPlace(Person person, string region)
    {
        Birthplaces[person] = region;
    }

    public static void AddEvent(string eventName, string officialVersion)
    {
        OfficialVersions[eventName] = officialVersion;
    }

    public static void AddRegionalVersion(string eventName, string region, string version)
    {
        if (!RegionalVersions.ContainsKey(eventName))
            RegionalVersions[eventName] = new();

        RegionalVersions[eventName][region] = version;
    }

    public static string Teach(Person person, string eventName)
    {
        var region = Birthplaces.TryGetValue(person, out var r) ? r : "unknown";
        var version = OfficialVersions.TryGetValue(eventName, out var off) ? off : "desconhecido";

        if (RegionalVersions.ContainsKey(eventName) && RegionalVersions[eventName].TryGetValue(region, out var alt))
            version = alt;

        person.Mind.Memory.AddMemory($"Aprendeu sobre {eventName}: {version}", 0.3f, 0f, new() { "hist\u00f3ria" }, "ensino");
        return version;
    }
}
