namespace UltraWorldAI.ModScripting;

public interface IModScript
{
    string Name { get; }
    void Initialize(ModContext context);
    void Execute(ModContext context);
}

