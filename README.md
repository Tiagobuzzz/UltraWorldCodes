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
