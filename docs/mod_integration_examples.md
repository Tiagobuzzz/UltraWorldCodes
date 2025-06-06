# Mod Integration Examples

Mods can extend the game by referencing `UltraWorldAI.dll` and interacting with public APIs.
The `ModScriptEngine` component loads external scripts placed under the `ModScripting` directory.
A minimal mod might register a new command:

```csharp
public static class ExampleMod
{
    public static void Register()
    {
        ModSupport.RegisterCommand("shout", (p, args) => Logger.Log($"{p.Name} shouts {string.Join(' ', args)}"));
    }
}
```
