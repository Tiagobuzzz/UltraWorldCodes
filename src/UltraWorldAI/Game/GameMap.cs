using System.Collections.Generic;

namespace UltraWorldAI.Game;

public class Tile
{
    public List<Person> Occupants { get; } = new();
    public bool IsObstacle { get; set; }
}

public class GameMap
{
    private readonly Tile[,] _tiles;
    public int Width { get; }
    public int Height { get; }

    public GameMap(int width, int height)
    {
        Width = width;
        Height = height;
        _tiles = new Tile[width, height];
        for (int x = 0; x < width; x++)
        for (int y = 0; y < height; y++)
            _tiles[x, y] = new Tile();
    }

    public void SetObstacle(int x, int y, bool value)
    {
        if (IsInside(x, y))
            _tiles[x, y].IsObstacle = value;
    }

    public bool IsObstacleAt(int x, int y) => IsInside(x, y) && _tiles[x, y].IsObstacle;

    public void Place(Person person, int x, int y)
    {
        if (IsInside(x, y) && !_tiles[x, y].IsObstacle)
            _tiles[x, y].Occupants.Add(person);
    }

    public void Move(Person person, int fromX, int fromY, int toX, int toY)
    {
        if (!IsInside(toX, toY) || _tiles[toX, toY].IsObstacle) return;
        _tiles[fromX, fromY].Occupants.Remove(person);
        _tiles[toX, toY].Occupants.Add(person);
        person.MoveTo($"Tile {toX},{toY}", toX, toY);
    }

    public string Render()
    {
        var sb = new System.Text.StringBuilder();
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                if (_tiles[x, y].IsObstacle)
                    sb.Append('#');
                else
                    sb.Append(_tiles[x, y].Occupants.Count > 0 ? 'O' : '.');
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }

    private bool IsInside(int x, int y) => x >= 0 && y >= 0 && x < Width && y < Height;
}
