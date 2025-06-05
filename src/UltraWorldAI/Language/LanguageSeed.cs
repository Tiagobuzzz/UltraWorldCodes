using System.Collections.Generic;

namespace UltraWorldAI.Language;

public class LanguageSeed
{
    public string Name { get; set; } = string.Empty;
    public List<string> Phonemes { get; set; } = new();
}
