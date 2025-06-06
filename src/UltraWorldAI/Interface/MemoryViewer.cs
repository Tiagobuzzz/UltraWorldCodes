using System;

namespace UltraWorldAI.Interface;

public static class MemoryViewer
{
    public static void Display(MemorySystem memory)
    {
        Console.WriteLine("=== Memórias ===");
        foreach (var mem in memory.Memories)
        {
            Console.WriteLine($"- {mem.Date.ToShortDateString()} {mem.Summary}");
        }
    }
}
