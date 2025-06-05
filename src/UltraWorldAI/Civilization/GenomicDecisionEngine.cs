using UltraWorldAI.Civilization;
using UltraWorldAI.Biology;

namespace UltraWorldAI.Civilization;

public static class GenomicDecisionEngine
{
    public static string Decide(SapientBeing being)
    {
        var expressed = being.GeneticCode.GetPhenotype().ToLower();

        if (expressed.Contains("fome")) return "Caçar ou buscar alimento";
        if (expressed.Contains("empatia")) return "Socializar e formar vínculos";
        if (expressed.Contains("visão noturna")) return "Explorar à noite";
        if (expressed.Contains("camuflagem")) return "Evitar conflito, se esconder";
        if (expressed.Contains("magnetismo mental")) return "Influenciar outras IAs";

        return "Ação neutra";
    }
}
