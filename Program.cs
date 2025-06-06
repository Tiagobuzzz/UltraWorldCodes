using UltraWorldAI;
using UltraWorldAI.Game;

public class Program
{
    public static void Main(string[] args)
    {
        string configPath = args.Length > 0 ? args[0] : "AIConfig.json";
        IA.Initialize(configPath);
        var observer = args.Length > 1 && args[1] == "--observe";
        AISettings.ObserverMode = observer;
        var loop = new GameLoop(5, 5, true, observer);
        var alice = new Person("Alice");
        var bob = new Person("Bob");
        alice.Inventory.Add(new Item("Key"));
        alice.AddExperience("Spawned", 0.4f, 0.1f);
        bob.AddExperience("Spawned", 0.4f, -0.1f);
        loop.AddPerson(alice, 2, 2);
        loop.AddPerson(bob, 1, 1);
        loop.Run(3);
        System.Console.WriteLine(alice.ReflectOnSelf());
        System.Console.WriteLine(bob.ReflectOnSelf());
    }
}
