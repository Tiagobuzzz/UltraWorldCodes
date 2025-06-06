using System;

namespace UltraWorldAI.Game;

/// <summary>
/// Simple 3x3 grid mini-game used in the tutorial.
/// The player moves with WASD to collect the '*' item.
/// </summary>
public class TutorialMiniGame
{
    private int _px;
    private int _py;
    private readonly int _itemX = 2;
    private readonly int _itemY = 2;

    public void Run()
    {
        Console.WriteLine("Bem-vindo ao mini tutorial! Use WASD para mover.");
        Draw();
        while (_px != _itemX || _py != _itemY)
        {
            var key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.W: _py--; break;
                case ConsoleKey.S: _py++; break;
                case ConsoleKey.A: _px--; break;
                case ConsoleKey.D: _px++; break;
                default: continue;
            }
            _px = Math.Clamp(_px, 0, 2);
            _py = Math.Clamp(_py, 0, 2);
            Draw();
        }
        Console.WriteLine("Item encontrado!");
    }

    private void Draw()
    {
        Console.Clear();
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                if (x == _px && y == _py) Console.Write('@');
                else if (x == _itemX && y == _itemY) Console.Write('*');
                else Console.Write('.');
            }
            Console.WriteLine();
        }
    }
}
