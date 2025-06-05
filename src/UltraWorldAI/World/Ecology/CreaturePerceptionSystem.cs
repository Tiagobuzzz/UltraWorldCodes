using System.Collections.Generic;

namespace UltraWorldAI;

public enum CreatureReaction { Ignora, Venera, Domestica, Caça, Foge, Estuda }

public class PerceivedCreature
{
    public string SpeciesName { get; set; } = string.Empty;
    public CreatureReaction Reaction { get; set; }
    public string Reason { get; set; } = string.Empty;
}

public static class CreaturePerceptionSystem
{
    public static Dictionary<string, List<PerceivedCreature>> IAReactions { get; } = new();

    public static void RegisterReaction(string brainID, string species, string phenotype)
    {
        var list = IAReactions.ContainsKey(brainID) ? IAReactions[brainID] : IAReactions[brainID] = new();

        CreatureReaction reaction = CreatureReaction.Ignora;
        string reason = "Sem interesse";

        if (phenotype.Contains("veneno"))
        {
            reaction = CreatureReaction.Foge;
            reason = "Potencial letal";
        }
        else if (phenotype.Contains("beleza"))
        {
            reaction = CreatureReaction.Venera;
            reason = "Forma estética rara";
        }
        else if (phenotype.Contains("força"))
        {
            reaction = CreatureReaction.Estuda;
            reason = "Valor tático";
        }
        else if (phenotype.Contains("carne"))
        {
            reaction = CreatureReaction.Caça;
            reason = "Fonte alimentar";
        }
        else if (phenotype.Contains("pelagem") || phenotype.Contains("utilidade"))
        {
            reaction = CreatureReaction.Domestica;
            reason = "Uso cultural/prático";
        }

        list.Add(new PerceivedCreature
        {
            SpeciesName = species,
            Reaction = reaction,
            Reason = reason
        });
    }
}
