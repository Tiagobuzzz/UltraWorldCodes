using System;
using System.Collections.Generic;

namespace UltraWorldAI.Interface;

/// <summary>
/// Provides a simple narrated tutorial that advances through predefined steps.
/// </summary>
public class TutorialSystem
{
    private readonly Queue<string> _steps = new();

    public TutorialSystem(IEnumerable<string> steps)
    {
        foreach (var step in steps)
            _steps.Enqueue(step);
    }

    /// <summary>
    /// Returns the next step text or null if finished.
    /// </summary>
    public string? NextStep()
    {
        return _steps.Count > 0 ? _steps.Dequeue() : null;
    }

    /// <summary>
    /// Runs the tutorial interactively, waiting for user confirmation between steps.
    /// </summary>
    public void RunInteractive()
    {
        while (_steps.Count > 0)
        {
            Console.WriteLine(NextStep());
            Console.ReadKey(true);
        }
    }
}
