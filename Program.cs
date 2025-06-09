using System;
using UltraWorldAI;
using UltraWorldAI.Game;

public class Program
{
    public static async System.Threading.Tasks.Task Main(string[] args)
    {
        string configPath = "AIConfig.json";
        bool observer = false;
        bool display = true;
        int width = 5;
        int height = 5;
        int steps = 3;
        foreach (var arg in args)
        {
            if (arg.StartsWith("--config=")) configPath = arg.Substring(9);
            else if (arg == "--observe") observer = true;
            else if (arg == "--no-display") display = false;
            else if (arg.StartsWith("--width=")) int.TryParse(arg.Substring(8), out width);
            else if (arg.StartsWith("--height=")) int.TryParse(arg.Substring(9), out height);
            else if (arg.StartsWith("--steps=")) int.TryParse(arg.Substring(8), out steps);
        }

        // Use simple console logging instead of Microsoft.Extensions.Logging
        IA.Initialize(configPath);
        AISettings.ObserverMode = observer;
        var loop = new GameLoop(width, height, display, observer);
        var alice = new Person("Alice");
        var bob = new Person("Bob");
        alice.Inventory.Add(new Item("Key"));
        alice.AddExperience("Spawned", 0.4f, 0.1f);
        bob.AddExperience("Spawned", 0.4f, -0.1f);
        loop.AddPerson(alice, 2, 2);
        loop.AddPerson(bob, 1, 1);
        await foreach (var state in loop.RunAsync(steps))
        {
            if (display)
                Console.WriteLine(state);
        }
        Console.WriteLine(alice.ReflectOnSelf());
        Console.WriteLine(bob.ReflectOnSelf());
    }
}
