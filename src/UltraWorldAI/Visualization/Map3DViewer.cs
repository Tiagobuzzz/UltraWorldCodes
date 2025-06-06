using System;
using UltraWorldAI.Game;

namespace UltraWorldAI.Visualization;

/// <summary>
/// Placeholder 3D viewer for generated maps.
/// </summary>
public static class Map3DViewer
{
    public static void Render(GameMap map)
    {
        Console.WriteLine($"Renderizando mapa {map.Width}x{map.Height} em 3D...");
    }
}
