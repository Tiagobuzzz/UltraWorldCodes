using System;
using UltraWorldAI;

class Program
{
    static void Main()
    {
        IA.Initialize();

        var alice = new Person("Alice");
        alice.AddExperience("confrontou um rival", intensity: 0.8f, emotionalCharge: 0.6f);
        alice.AddExperience("isolou-se para meditar", intensity: 0.5f);

        alice.Update();

        Console.WriteLine("Reflexão interna:");
        Console.WriteLine(alice.ReflectOnSelf());

        Console.WriteLine("Próxima ação sugerida: " + alice.Mind.Behavior.DecideNextAction());
    }
}
