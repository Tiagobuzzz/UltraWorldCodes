using System;

namespace UltraWorldAI.Biology;

public class AdvancedGene
{
    public string Trait { get; set; } = string.Empty;
    public string AlleleA { get; set; } = string.Empty;
    public string AlleleB { get; set; } = string.Empty;
    public AlleleType ExpressionType { get; set; }
    public Func<string, string, string>? ExpressionRule { get; set; }

    public string Expressed()
    {
        if (ExpressionRule != null)
            return ExpressionRule.Invoke(AlleleA, AlleleB);

        if (AlleleA == AlleleB)
            return AlleleA;

        if (ExpressionType == AlleleType.Dominant)
            return AlleleA == AlleleA.ToUpper() ? AlleleA : AlleleB;

        return AlleleA == AlleleA.ToLower() ? AlleleA : AlleleB;
    }
}
