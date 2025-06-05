using UltraWorldAI;
using UltraWorldAI.Religion;
using Xunit;

public class FaithSystemTests
{
    [Fact]
    public void FollowGodCreatesFaithStatus()
    {
        var faith = new FaithSystem();
        var god = new DivineBeing { Name = "Ipona", Domain = DivineDomain.Memoria };

        faith.FollowGod("b1", god);
        var status = faith.GetFaithStatus("b1");

        Assert.NotNull(status);
        Assert.Equal(god.Name, status!.God.Name);
        Assert.Contains("fala comigo", status.PersonalInterpretations[0]);
    }

    [Fact]
    public void LosingFaithCanLeadToHeresy()
    {
        var faith = new FaithSystem();
        var god = new DivineBeing { Name = "Ipona" };

        faith.FollowGod("b2", god);
        for (int i = 0; i < 5; i++)
        {
            faith.LoseFaith("b2", "crise");
        }

        var status = faith.GetFaithStatus("b2");
        Assert.True(status!.IsHeretical);
        Assert.Contains(status.PersonalInterpretations, p => p.Contains("Rompeu"));
    }
}
