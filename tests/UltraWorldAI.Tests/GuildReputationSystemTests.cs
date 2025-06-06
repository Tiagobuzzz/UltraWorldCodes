using UltraWorldAI.Economy;
using Xunit;

public class GuildReputationSystemTests
{
    [Fact]
    public void RegisterAndReputationWorks()
    {
        GuildReputationSystem.Reputations.Clear();
        GuildReputationSystem.RegisterGuild("Mercadores");
        GuildReputationSystem.AdjustMemberScore("Mercadores", "Alice", 5);
        GuildReputationSystem.AdjustMemberScore("Mercadores", "Bob", -1);

        Assert.Single(GuildReputationSystem.Reputations);
        Assert.Equal(2, GuildReputationSystem.Reputations[0].MemberScores.Count);
        Assert.Equal(2f, GuildReputationSystem.GetGuildReputation("Mercadores"));
    }
}

