using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Traditions;

public class OralStory
{
    public string Speaker { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}

public class OralTraditionRecorder
{
    private readonly List<OralStory> _stories = new();

    public IReadOnlyList<OralStory> Stories => _stories;

    public void Record(string speaker, string text)
    {
        _stories.Add(new OralStory { Speaker = speaker, Text = text, Date = DateTime.Now });
    }

    public string NarrateAll() => string.Join("\n", _stories.Select(s => $"{s.Speaker}: {s.Text}"));
}
