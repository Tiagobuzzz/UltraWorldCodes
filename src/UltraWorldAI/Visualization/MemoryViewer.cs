using System;
using System.Collections.Generic;

namespace UltraWorldAI.Visualization;

public static class MemoryViewer
{
    public static void Display(IEnumerable<Memory> memories)
    {
        Console.WriteLine("\uD83D\uDCCA Memórias");
        foreach (var mem in memories)
        {
            Console.WriteLine($"- [{mem.Date:yyyy-MM-dd}] {mem.Summary} ({mem.Intensity:F2})");
        }
    }
}
