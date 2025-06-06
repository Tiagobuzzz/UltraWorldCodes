using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI;

public partial class MemorySystem
{
    /// <summary>
    /// Retrieves a ranked list of memories matching the provided keyword.
    /// The act of retrieval slightly refreshes their intensity.
    /// </summary>
    public List<Memory> RetrieveMemories(string keyword, int count = 5)
    {
        var now = DateTime.Now;
        var lower = keyword?.Trim().ToLowerInvariant();
        var cacheKey = $"{lower}|{count}";
        if (_keywordCache.TryGetValue(cacheKey, out var cached))
            return new List<Memory>(cached);
        System.Text.RegularExpressions.Regex? regex = null;
        if (!string.IsNullOrWhiteSpace(lower))
            regex = new System.Text.RegularExpressions.Regex(System.Text.RegularExpressions.Regex.Escape(lower!),
                System.Text.RegularExpressions.RegexOptions.IgnoreCase |
                System.Text.RegularExpressions.RegexOptions.Compiled);
        var results = new List<(Memory mem, float weight)>();

        foreach (var m in Memories)
        {
            bool matches = regex == null;
            if (!matches)
            {
                foreach (var k in m.Keywords)
                {
                    if (regex!.IsMatch(k))
                    {
                        matches = true;
                        break;
                    }
                }

                if (!matches && regex!.IsMatch(m.Summary))
                    matches = true;
            }

            if (matches)
            {
                float weight = (m.Intensity * 0.6f) +
                               (Math.Abs(m.EmotionalCharge) * 0.3f) +
                               (float)(1.0 / (1.0 + (now - m.Date).TotalDays));
                results.Add((m, weight));
            }
        }

        var sorted = results
            .OrderByDescending(r => r.weight)
            .Take(count)
            .Select(r => r.mem)
            .ToList();

        foreach (var mem in sorted)
        {
            mem.Intensity = Math.Min(1f, mem.Intensity + 0.05f);
        }

        _keywordCache[cacheKey] = new List<Memory>(sorted);

        return sorted;
    }

    /// <summary>
    /// Retrieves memories tagged with a specific emotion label.
    /// </summary>
    public List<Memory> RetrieveMemoriesByEmotion(string emotion, int count = 5)
    {
        var lower = emotion.ToLowerInvariant();
        var cacheKey = $"{lower}|{count}";
        if (_emotionCache.TryGetValue(cacheKey, out var cached))
            return new List<Memory>(cached);
        var matches = new List<Memory>();
        foreach (var m in Memories)
        {
            if (string.Equals(m.Emotion, lower, StringComparison.OrdinalIgnoreCase))
                matches.Add(m);
        }

        var results = matches
            .OrderByDescending(m => m.Intensity)
            .Take(count)
            .ToList();

        foreach (var mem in results)
        {
            mem.Intensity = Math.Min(1f, mem.Intensity + 0.05f);
        }

        _emotionCache[cacheKey] = new List<Memory>(results);

        return results;
    }

    /// <summary>Returns the most intense memory or null if none exist.</summary>
    public Memory? GetMostIntenseMemory()
    {
        return Memories.OrderByDescending(m => m.Intensity).FirstOrDefault();
    }

    /// <summary>Removes memories containing the specified keyword.</summary>
    public void RemoveMemoriesByKeyword(string keyword)
    {
        ClearCache();
        var lower = keyword.ToLowerInvariant();
        var regex = new System.Text.RegularExpressions.Regex(System.Text.RegularExpressions.Regex.Escape(lower),
            System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Compiled);
        Memories.RemoveAll(m =>
        {
            foreach (var k in m.Keywords)
            {
                if (regex.IsMatch(k))
                    return true;
            }
            return regex.IsMatch(m.Summary);
        });
    }
}
