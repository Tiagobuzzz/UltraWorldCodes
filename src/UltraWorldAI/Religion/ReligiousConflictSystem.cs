using System;
using UltraWorldAI.Politics;

namespace UltraWorldAI.Religion;

public static class ReligiousConflictSystem
{
    public static void ProclaimProphecy(string religionName, string title, string trigger, string prediction)
    {
        var religion = ReligionSystem.Religions.Find(r => r.Name == religionName);
        if (religion == null) return;

        ProphecySystem.Create(title, religionName, "sacerdotes", trigger, prediction);
        HistorySystem.LogEvent($"{religionName} proclamou a profecia '{title}'");
    }

    public static void TriggerSchism(string doctrineTitle, string founderId, string reason)
    {
        var doctrine = DoctrineEngine.Doctrines.Find(d => d.Title == doctrineTitle);
        if (doctrine == null) return;

        var cult = CultSplit.CreateCultFromDoctrine(doctrine, founderId, reason);
        HistorySystem.LogEvent($"{founderId} fundou o culto {cult.Name}");
    }

    public static void StartHolyWar(string religionName, string region)
    {
        var religion = ReligionSystem.Religions.Find(r => r.Name == religionName);
        if (religion == null) return;

        var cause = $"Guerra santa de {religionName} em {region}";
        HouseWarSystem.DeclareWar(religionName, region, cause);
        HistorySystem.LogEvent(cause);
    }
}
