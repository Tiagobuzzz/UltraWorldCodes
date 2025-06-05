namespace UltraWorldAI.Language;

public static class TranslationDifficultyCalculator
{
    public static int Calculate(LanguageSeed a, LanguageSeed b)
    {
        int overlap = 0;
        foreach (var phon in a.Phonemes)
        {
            if (b.Phonemes.Contains(phon))
                overlap++;
        }
        return a.Phonemes.Count + b.Phonemes.Count - 2 * overlap;
    }
}
