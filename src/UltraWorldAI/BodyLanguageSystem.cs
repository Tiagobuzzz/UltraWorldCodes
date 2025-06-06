using System;

namespace UltraWorldAI;

/// <summary>
/// Provides simple body language interactions.
/// </summary>
public enum Gesture
{
    Nod,
    Bow,
    Wave,
    Point
}

public static class BodyLanguageSystem
{
    public static void PerformGesture(Person actor, Gesture gesture, Person? target = null)
    {
        string gestureText = gesture.ToString();
        string message = target == null
            ? $"{actor.Name} faz o gesto: {gestureText}."
            : $"{actor.Name} direciona {gestureText} para {target.Name}.";
        Console.WriteLine(message);
    }
}
