namespace UltraWorldAI.Politics;

public static class MoralDecisionEngine
{
    public static bool ShouldSupportLaw(Person leader, string law)
    {
        var morality = leader.Mind.Ethics.EvaluateMorality(law);
        return morality > 0.5f;
    }
}
