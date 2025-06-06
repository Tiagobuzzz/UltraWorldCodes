using UltraWorldAI.History;

namespace UltraWorldAI.World;

/// <summary>
/// Sets up a new simulation starting in a pre-stone age era with no knowledge.
/// </summary>
public static class PrehistoricWorldInitializer
{
    /// <summary>
    /// Clears the given person's memories and knowledge and registers the
    /// starting technological era.
    /// </summary>
    public static void Initialize(Person person)
    {
        person.Mind.Memory.ClearAllMemories();
        person.Mind.Knowledge.ClearFacts();
        TechTimelineSystem.Eras.Clear();
        TechTimelineSystem.CreateEra("Pré-Pedra", "primitivo");
    }
}
