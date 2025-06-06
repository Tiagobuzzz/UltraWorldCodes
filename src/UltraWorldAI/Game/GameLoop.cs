using System;
using System.Collections.Generic;

namespace UltraWorldAI.Game;

public class GameLoop
{
    private readonly GameMap _map;
    private readonly List<(Person person, int x, int y, int? tx, int? ty)> _actors = new();
    private readonly Random _rng = new();
    private readonly bool _display;
    private GameDifficulty _difficulty = GameDifficulty.Normal;

    public GameDifficulty Difficulty
    {
        get => _difficulty;
        set => _difficulty = value;
    }

    public int StepRange => _difficulty switch
    {
        GameDifficulty.Easy => 1,
        GameDifficulty.Normal => 1,
        GameDifficulty.Hard => 2,
        _ => 1
    };

    public GameLoop(int width, int height, bool display = false)
    {
        _map = new GameMap(width, height);
        _display = display;
    }

    public void AddPerson(Person person, int x, int y, int? targetX = null, int? targetY = null)
    {
        _actors.Add((person, x, y, targetX, targetY));
        _map.Place(person, x, y);
    }

    public void Run(int steps)
    {
        for (int step = 0; step < steps; step++)
        {
            System.Threading.Tasks.Parallel.For(0, _actors.Count, i =>
            {
                var actor = _actors[i];
                actor.person.Update();
                int newX = actor.x;
                int newY = actor.y;

                if (actor.tx.HasValue && actor.ty.HasValue)
                {
                    var path = Pathfinder.FindPath(_map, actor.x, actor.y, actor.tx.Value, actor.ty.Value);
                    if (path.Count > 0)
                    {
                        var stepTo = path[0];
                        newX = stepTo.x;
                        newY = stepTo.y;
                    }
                }
                else
                {
                    int range = StepRange;
                    newX += _rng.Next(-range, range + 1);
                    newY += _rng.Next(-range, range + 1);
                }

                newX = Math.Clamp(newX, 0, _map.Width - 1);
                newY = Math.Clamp(newY, 0, _map.Height - 1);

                _map.Move(actor.person, actor.x, actor.y, newX, newY);
                _actors[i] = (actor.person, newX, newY, actor.tx, actor.ty);
            });

            if (_display)
            {
                Console.WriteLine($"Step {step + 1}\n{_map.Render()}");
            }
        }
    }
}
