using UltraWorldAI;

public class Program
{
    public static void Main(string[] args)
    {
        IA.Initialize();
        var person = new Person("Demo");
        person.AddExperience("Started simulation", 0.5f, 0.2f);
        person.Update();
        System.Console.WriteLine(person.ReflectOnSelf());
    }
}
