using System.Collections.Generic;

namespace UltraWorldAI.Arts;

public class ArtPiece
{
    public string Type { get; set; } = string.Empty; // música, pintura, teatro
    public string Title { get; set; } = string.Empty;
    public string Creator { get; set; } = string.Empty;
}

public static class ArtsSystem
{
    private static readonly Dictionary<string, List<ArtPiece>> _arts = new();

    public static void AddArt(string culture, ArtPiece art)
    {
        if (!_arts.ContainsKey(culture))
            _arts[culture] = new List<ArtPiece>();
        _arts[culture].Add(art);
    }

    public static List<ArtPiece> GetArts(string culture)
    {
        return _arts.TryGetValue(culture, out var list) ? list : new List<ArtPiece>();
    }
}
