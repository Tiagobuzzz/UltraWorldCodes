namespace UltraWorldAI.Economy;

using System.Collections.Generic;
using System.Linq;

public class GuildReputation
{
    public string Guild { get; set; } = string.Empty;
    public Dictionary<string, float> MemberScores { get; } = new();

    public float Reputation => MemberScores.Count == 0
        ? 0f
        : MemberScores.Values.Sum() / MemberScores.Count;
}

public static class GuildReputationSystem
{
    public static List<GuildReputation> Reputations { get; } = new();

    public static void RegisterGuild(string name)
    {
        if (Reputations.Any(r => r.Guild == name)) return;
        Reputations.Add(new GuildReputation { Guild = name });
    }

    public static void AdjustMemberScore(string guild, string member, float delta)
    {
        var rep = Reputations.FirstOrDefault(r => r.Guild == guild);
        if (rep == null) return;
        if (!rep.MemberScores.ContainsKey(member)) rep.MemberScores[member] = 0f;
        rep.MemberScores[member] += delta;
    }

    public static float GetMemberScore(string guild, string member)
    {
        var rep = Reputations.FirstOrDefault(r => r.Guild == guild);
        if (rep == null) return 0f;
        return rep.MemberScores.TryGetValue(member, out var val) ? val : 0f;
    }

    public static float GetGuildReputation(string guild)
    {
        var rep = Reputations.FirstOrDefault(r => r.Guild == guild);
        return rep?.Reputation ?? 0f;
    }
}

