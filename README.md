# UltraWorldCodes
This repository contains the game code and the AI module. The AI logic is a
single file with several interlinked systems that model memory, beliefs,
personality, emotions and more.

## Structure
- `src/UltraWorldAI/IA.cs` contains the main AI implementation. It defines all
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
