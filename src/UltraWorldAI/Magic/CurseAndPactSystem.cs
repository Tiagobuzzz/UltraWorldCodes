using System;
using System.Collections.Generic;

namespace UltraWorldAI.Magic;

public class Curse
{
    public string Name = string.Empty;
    public string Trigger = string.Empty; // "Matar inocente", "Falar o nome proibido"
    public string Effect = string.Empty; // "Pele apodrece", "Voz é roubada"
    public bool CanBeLifted;
}

public class Pact
{
    public string EntityName = string.Empty;
    public string Condition = string.Empty; // "Serviço eterno", "Sacrifício do primogênito"
    public string Reward = string.Empty;
    public bool IsBinding;
}

public static class CurseAndPactSystem
{
    public static List<Curse> Curses { get; } = new();
    public static List<Pact> Pacts { get; } = new();

    public static void CreateCurse(string name, string trigger, string effect, bool liftable)
    {
        Curses.Add(new Curse { Name = name, Trigger = trigger, Effect = effect, CanBeLifted = liftable });
        Console.WriteLine($"\uD83D\uDDFF Maldi\u00E7\u00E3o: {name} | Gatilho: {trigger} | Efeito: {effect}");
    }

    public static void CreatePact(string entity, string condition, string reward, bool binding)
    {
        Pacts.Add(new Pact { EntityName = entity, Condition = condition, Reward = reward, IsBinding = binding });
        Console.WriteLine($"\uD83D\uDCDC Pacto com {entity} | Condi\u00E7\u00E3o: {condition} | Recompensa: {reward} | Vinculativo: {binding}");
    }
}
