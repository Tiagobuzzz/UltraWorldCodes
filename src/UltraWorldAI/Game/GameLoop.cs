using System;
using System.Collections.Generic;

namespace UltraWorldAI.Game;

public class GameLoop
{
    private readonly GameMap _map;
    private readonly List<(Person person, int x, int y)> _actors = new();
    private readonly Random _rng = new();

    public GameLoop(int width, int height)
    {
        _map = new GameMap(width, height);
    }

    public void AddPerson(Person person, int x, int y)
    {
        _actors.Add((person, x, y));
        _map.Place(person, x, y);
    }

    public void Run(int steps)
    {
        for (int step = 0; step < steps; step++)
        {
            for (int i = 0; i < _actors.Count; i++)
            {
                var actor = _actors[i];
                actor.person.Update();
                int newX = actor.x + _rng.Next(-1, 2);
                int newY = actor.y + _rng.Next(-1, 2);
                newX = Math.Clamp(newX, 0, _map.Width - 1);
                newY = Math.Clamp(newY, 0, _map.Height - 1);
                _map.Move(actor.person, actor.x, actor.y, newX, newY);
                _actors[i] = (actor.person, newX, newY);
            }
        }
    }
}
