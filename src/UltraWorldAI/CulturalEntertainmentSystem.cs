using System.Collections.Generic;

namespace UltraWorldAI;

/// <summary>
/// Maintains entertainment and media for cultures.
/// </summary>
public static class CulturalEntertainmentSystem
{
    private static readonly Dictionary<string, List<string>> _media = new();

    public static void AddMedia(string culture, string media)
    {
        if (!_media.ContainsKey(culture))
            _media[culture] = new List<string>();
        _media[culture].Add(media);
    }

    public static List<string> GetMedia(string culture)
    {
        return _media.TryGetValue(culture, out var list) ? list : new List<string>();
    }
}

