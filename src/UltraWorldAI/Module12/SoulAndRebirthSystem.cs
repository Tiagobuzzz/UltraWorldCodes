using System;
using System.Collections.Generic;

namespace UltraWorldAI.Module12;

public enum SoulState
{
    Wandering,
    Reincarnated,
    BoundToPlace,
    Forgotten
}

public class Soul
{
    public string OriginalName { get; set; } = string.Empty;
    public SoulState State { get; set; }
    public string MemoryEcho { get; set; } = string.Empty;
    public string? NewIdentity { get; set; }
}

public static class SoulAndRebirthSystem
{
    public static List<Soul> Souls { get; } = new();

    public static void ProcessSoul(string name, SoulState state, string echo, string? newID = null)
    {
        Souls.Add(new Soul
        {
            OriginalName = name,
            State = state,
            MemoryEcho = echo,
            NewIdentity = newID
        });

        Console.WriteLine($"\uD83D\uDC7B Alma: {name} | Estado: {state} | Eco: {echo} | Nova identidade: {newID ?? "N/A"}");
    }

    public static void PrintSouls()
    {
        foreach (var s in Souls)
            Console.WriteLine($"\n\uD83C\uDF2B️ {s.OriginalName} | Estado: {s.State} | Eco: {s.MemoryEcho} | Nova forma: {s.NewIdentity ?? "Nenhuma"}");
    }
}
