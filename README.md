# UltraWorldCodes
This repository contains the game code and the AI module.

## Structure
- `src/UltraWorldAI/IA.cs` contains the main AI implementation.
- `AIConfig.json` can override some runtime parameters.

## Building
This project does not ship a full `.csproj` out of the box. To compile it you 
need the [.NET SDK](https://dotnet.microsoft.com/download). A quick way to 
experiment is to create a console project and copy `IA.cs` into it:

```bash
dotnet new console -n Demo
cd Demo
cp ../src/UltraWorldAI/IA.cs .
dotnet build
```

You can then run the project with `dotnet run`.

## Using the AI
The main entry point for the AI is the `Person` class. After building the 
project you can create a person, give them experiences and retrieve a 
self-reflection:

```csharp
using UltraWorldAI;

AISettings.Load("../AIConfig.json");
var bob = new Person("Bob");
bob.AddExperience("won a contest", intensity: 0.8f);
Console.WriteLine(bob.ReflectOnSelf());
```

The call to `AISettings.Load` reads configuration values such as 
`MaxMemories` from `AIConfig.json`.
