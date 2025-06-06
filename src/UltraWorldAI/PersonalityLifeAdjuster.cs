using System;

namespace UltraWorldAI;

public static class PersonalityLifeAdjuster
{
    public static void Apply(Person person)
    {
        switch (person.CurrentLifeStage)
        {
            case LifeStage.Infantil:
                person.Mind.Personality.AdjustTrait("Curiosity", 0.01f);
                break;
            case LifeStage.Crianca:
                person.Mind.Personality.AdjustTrait("Amabilidade", 0.01f);
                break;
            case LifeStage.Adolescente:
                person.Mind.Personality.AdjustTrait("Neuroticismo", 0.01f);
                break;
            case LifeStage.Adulto:
                person.Mind.Personality.AdjustTrait("Conscienciosidade", 0.005f);
                break;
            case LifeStage.Idoso:
                person.Mind.Personality.AdjustTrait("Amabilidade", 0.005f);
                break;
        }
    }
}
