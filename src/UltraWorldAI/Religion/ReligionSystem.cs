using System.Collections.Generic;

namespace UltraWorldAI.Religion;

public class Religion
{
    public string Name { get; set; } = string.Empty;
    public string Doctrine { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
}

public static class ReligionSystem
{
    public static List<Religion> Religions { get; } = new();

    public static Religion FoundReligion(string name, string doctrine, string region)
    {
        var r = new Religion { Name = name, Doctrine = doctrine, Region = region };
        Religions.Add(r);
        return r;
    }
}
