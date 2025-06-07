using System;

namespace UltraWorldAI.Module15;

public static class StyleInheritanceSystem
{
    public static string InheritStyle(string parentStyle, string descendant)
    {
        var newStyle = $"{parentStyle} ({descendant})";
        Console.WriteLine($"\uD83E\uDDE9 {descendant} herdou o estilo: {parentStyle}");
        return newStyle;
    }
}
