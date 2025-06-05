# UltraWorldCodes

This repository contains the game code and the AI module. The AI logic is
split across several files under `src/UltraWorldAI/`, each implementing
interlinked systems that model memory, beliefs, personality, emotions and more.

## Structure
- The `src/UltraWorldAI/` directory contains the implementation of all
  subsystems such as memory, beliefs, metacognition and the narrative engine.
- `AIConfig.json` can override some runtime parameters (like `MaxMemories`).

### Features

- **Runtime settings** through `AISettings` with a small `Logger` utility.
- **Memory persistence** via `SaveMemories`/`LoadMemories` in `MemorySystem`.
- **Conflict events** (`ContradictionDetected` / `ContradictionResolved`) to
  monitor internal inconsistencies.
- **SelfNarrativeSystem** maintains core personal narratives and assists the narrative engine with psychological defenses.
- **NarrativeEngine** generates reflections and applies psychological defense
  mechanisms when contradictions arise.
- **SemanticMemory** stores durable conceptual knowledge that decays slowly over time.
- **ExternalSupportSystem** avalia pressões sociais, reputação e rituais que influenciam a mente.
- **InteractionSystem** permite comunicação simples entre agentes, afetando crenças e emoções.
- **Logger** suporta níveis de log e gravação em arquivo.
- **xUnit tests** verificam memórias e resolução de contradições.

## Building

Use the .NET 6 SDK to build the library. Run:

```bash
dotnet build src/UltraWorldAI/UltraWorldAI.csproj
```

Before instantiating any `Person` objects, call `IA.Initialize()` so that runtime settings are loaded from `AIConfig.json`.
=======
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

