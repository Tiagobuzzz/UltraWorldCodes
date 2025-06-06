using System;

namespace UltraWorldAI;

public static class LifeCycleSystem
{
    public static void Advance(Person person)
    {
        person.Age++;
        person.CurrentLifeStage = person.Age switch
        {
            < 3 => LifeStage.Infantil,
            < 12 => LifeStage.Crianca,
            < 18 => LifeStage.Adolescente,
            < 60 => LifeStage.Adulto,
            _ => LifeStage.Idoso
        };
        if (person.Age >= 80 && person.IsAlive)
            person.Die();
    }
}
