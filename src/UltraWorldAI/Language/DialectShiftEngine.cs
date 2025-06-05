using System.Collections.Generic;

namespace UltraWorldAI.Language;

public static class DialectShiftEngine
{
    public static void EvolveDialect(LanguageSeed language)
    {
        language.Phonemes.Add("x");
    }
}
