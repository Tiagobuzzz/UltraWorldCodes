using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Discovery;

public static class TechReawakening
{
    public static ConceptualTech? Reinterpret(string thinker, string forgottenTechName)
    {
        var original = TechCreator.TechPool.FirstOrDefault(t => t.Name == forgottenTechName);
        if (original == null) return null;

        var newConcepts = new List<string>(original.CombinedConcepts);
        newConcepts[new Random().Next(newConcepts.Count)] += "*";

        var reimagined = TechCreator.CreateTech(thinker, newConcepts);
        reimagined.Name = $"{original.Name}-Revivida";
        reimagined.HypotheticalFunction += " (reinterpretada)";

        return reimagined;
    }
}
