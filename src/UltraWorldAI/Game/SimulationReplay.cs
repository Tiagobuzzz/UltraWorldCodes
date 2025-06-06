using System;
using System.Collections.Generic;

namespace UltraWorldAI.Game;

public sealed class SimulationReplay
{
    private readonly List<string> _frames;
    public SimulationReplay(List<string> frames) => _frames = frames;
    public IEnumerable<string> Frames => _frames;

    public void Play(int delayMs = 0)
    {
        foreach (var f in _frames)
        {
            Console.WriteLine(f);
            if (delayMs > 0)
                System.Threading.Thread.Sleep(delayMs);
        }
    }
}
