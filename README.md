# UltraWorldCodes
This repository contains the game code and the AI module. The AI logic is
split across several files under `src/UltraWorldAI/`, each implementing
interlinked systems that model memory, beliefs, personality, emotions and more.

## Structure
- The `src/UltraWorldAI/` directory contains the implementation of all
  subsystems such as memory, beliefs, metacognition and the narrative engine.
- `AIConfig.json` can override some runtime parameters (like `MaxMemories`).

### Features

 - **Runtime settings** through `AISettings` with a small `Logger` utility (supports log levels).
- **Memory persistence** via `SaveMemories`/`LoadMemories` in `MemorySystem`.
- **Conflict events** (`ContradictionDetected` / `ContradictionResolved`) to
  monitor internal inconsistencies.
- **SelfNarrativeSystem** maintains core personal narratives and assists the narrative engine with psychological defenses.
- **NarrativeEngine** generates reflections and applies psychological defense
  mechanisms when contradictions arise.
- **SemanticMemory** stores durable conceptual knowledge that decays slowly over time.
- **BehaviorSystem** picks basic actions for a character based on mood and beliefs.

## Building

Use the .NET 6 SDK to build the library. Run:

```bash
dotnet build src/UltraWorldAI/UltraWorldAI.csproj
```

Before instantiating any `Person` objects, call `IA.Initialize()` so that runtime settings are loaded from `AIConfig.json`.

## Testing

Run unit tests with:

```bash
dotnet test tests/UltraWorldAI.Tests/UltraWorldAI.Tests.csproj
```

## Sample usage

A simple console app is provided under `samples/SampleApp` demonstrating how to
initialize the AI and generate a reflection:

```bash
dotnet run --project samples/SampleApp/SampleApp.csproj
```
