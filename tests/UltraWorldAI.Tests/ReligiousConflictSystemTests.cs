using UltraWorldAI;
using UltraWorldAI.Politics;
using UltraWorldAI.Religion;
using Xunit;

public class ReligiousConflictSystemTests
{
    [Fact]
    public void ProclaimProphecyAddsProphecyAndLogsEvent()
    {
        ReligionSystem.Religions.Clear();
        HistorySystem.Events.Clear();
        var religion = ReligionSystem.FoundReligion("Solaris", "Luz eterna", "Sul");
        var before = ProphecySystem.AllProphecies.Count;

        ReligiousConflictSystem.ProclaimProphecy(religion.Name, "Ascensao", "eclipse", "nova era");

        Assert.Equal(before + 1, ProphecySystem.AllProphecies.Count);
        Assert.Contains(HistorySystem.Events, e => e.EventName.Contains("proclamou a profecia"));
    }

    [Fact]
    public void TriggerSchismCreatesCultAndLogs()
    {
        CultSplit.AllCults.Clear();
        DoctrineEngine.Doctrines.Clear();
        HistorySystem.Events.Clear();
        var god = GodFactory.CreateGod("Zaros", DivineDomain.Luz, DivineTemperament.Benevolente);
        var doctrine = DoctrineEngine.CreateDoctrine(god);

        ReligiousConflictSystem.TriggerSchism(doctrine.Title, "Cyrus", "discordancia");

        Assert.Single(CultSplit.AllCults);
        Assert.Contains(HistorySystem.Events, e => e.EventName.Contains("fundou o culto"));
    }

    [Fact]
    public void StartHolyWarCreatesWarAndLogs()
    {
        ReligionSystem.Religions.Clear();
        HouseWarSystem.Wars.Clear();
        HistorySystem.Events.Clear();
        var religion = ReligionSystem.FoundReligion("Lunaris", "Sombra", "Norte");

        ReligiousConflictSystem.StartHolyWar(religion.Name, "Norte");

        Assert.Single(HouseWarSystem.Wars);
        Assert.Contains(HistorySystem.Events, e => e.EventName.Contains("Guerra santa"));
    }
}
