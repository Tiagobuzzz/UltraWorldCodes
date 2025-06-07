using UltraWorldAI.Religion;
using UltraWorldAI.World;
using UltraWorldAI.Time;
using UltraWorldAI;

namespace UltraWorldAI.DivineWorld;

public static class DivineIntegrationSystem
{
    public static void BlessPopulation(
        DivineBeing god,
        CultureSystem cultureSystem,
        PhilosophySystem philosophySystem,
        string cultureName,
        string region)
    {
        cultureSystem.PropagateBelief($"{god.Name} protege os fi\u00e9is", cultureName);
        AIPopulation.AdaptBehavior(cultureName, "segue rituais divinos");
        HistorySystem.LogEvent($"{god.Name} aben\u00e7oou {region}");
        EraTimelineSystem.AdvanceEpoch($"Era de {god.Name}");
        ReligionSystem.FoundReligion($"Culto de {god.Name}", $"Adora\u00e7\u00e3o do {god.Domain}", region);
        philosophySystem.SpreadDoctrine("O vazio \u00e9 divino");
        WorldMap.AddLandmark($"Templo de {god.Name}", true);
        AIBehavior.AvoidZone($"Templo de {god.Name}", "Temor ancestral da cria\u00e7\u00e3o divina");
        cultureSystem.DeclareSacredForm("Simetria Perfeita");
        MutationSystem.MutateCulture(cultureName, "Bra\u00e7os duplos crescem por devo\u00e7\u00e3o");
    }
}
