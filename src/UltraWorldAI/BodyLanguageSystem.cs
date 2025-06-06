using System;

namespace UltraWorldAI;

/// <summary>
/// Provides simple body language interactions.
/// </summary>
public static class BodyLanguageSystem
{
    public static void PerformGesture(Person actor, string gesture, Person? target = null)
    {
        string message = target == null
            ? $"{actor.Name} faz o gesto: {gesture}."
            : $"{actor.Name} direciona {gesture} para {target.Name}.";
        Console.WriteLine(message);
    }
}
