using UltraWorldAI;
using System;
using System.Collections.Generic;

namespace UltraWorldAI.Game;

public class GameLoop
{
    private readonly GameMap _map;
    private readonly List<(Person person, int x, int y, int? tx, int? ty)> _actors = new();
    private readonly bool _display;
    private readonly bool _observerMode;
    private readonly IPathfinder _pathfinder;
    private GameDifficulty _difficulty = GameDifficulty.Normal;
    private bool _paused;

    public event Action<Person>? PersonUpdated;

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

    public GameLoop(int width, int height, bool display = false, bool observerMode = false,
        IPathfinder? pathfinder = null, IMapGenerator? mapGenerator = null)
    {
        _map = (mapGenerator ?? new MapGenerator()).Generate(width, height);
        _display = display;
        _observerMode = observerMode;
        _pathfinder = pathfinder ?? new DefaultPathfinder();
    }

    public bool IsPaused => _paused;

    public void Pause() => _paused = true;
    public void Resume() => _paused = false;

    public void AddPerson(Person person, int x, int y, int? targetX = null, int? targetY = null)
    {
        _actors.Add((person, x, y, targetX, targetY));
        _map.Place(person, x, y);
    }

    public void Step()
    {
        if (_paused) return;
        System.Threading.Tasks.Parallel.For(0, _actors.Count, i =>
        {
            var actor = _actors[i];
            actor.person.Update();
            int newX = actor.x;
            int newY = actor.y;

            if (actor.tx.HasValue && actor.ty.HasValue)
            {
                var path = _pathfinder.FindPath(_map, actor.x, actor.y, actor.tx.Value, actor.ty.Value);
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
                newX += RandomProvider.Next(-range, range + 1);
                newY += RandomProvider.Next(-range, range + 1);
            }

            newX = Math.Clamp(newX, 0, _map.Width - 1);
            newY = Math.Clamp(newY, 0, _map.Height - 1);

            _map.Move(actor.person, actor.x, actor.y, newX, newY);
            _actors[i] = (actor.person, newX, newY, actor.tx, actor.ty);
            if (!_observerMode)
                PersonUpdated?.Invoke(actor.person);
        });
    }

    public void Run(int steps)
    {
        for (int step = 0; step < steps; step++)
        {
            Step();
            if (_display)
            {
                Console.WriteLine($"Step {step + 1}\n{_map.Render()}");
            }
        }
    }

    public SimulationReplay RunReplay(int steps)
    {
        var frames = new List<string>();
        for (int step = 0; step < steps; step++)
        {
            Step();
            var frame = _map.Render();
            frames.Add(frame);
            if (_display)
                Console.WriteLine($"Step {step + 1}\n{frame}");
        }
        return new SimulationReplay(frames);
    }

    public async IAsyncEnumerable<string> RunAsync(int steps)
    {
        for (int step = 0; step < steps; step++)
        {
            Step();
            yield return _map.Render();
            await System.Threading.Tasks.Task.Yield();
        }
    }
}
