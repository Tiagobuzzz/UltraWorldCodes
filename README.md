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
- **PhilosophySystem** builds core personal doctrines and checks if goals
  conflict with them.
- **SemanticMemory** stores durable conceptual knowledge that decays slowly over time.
- **ExternalSupportSystem** avalia pressões sociais, reputação e rituais que influenciam a mente.
- **InteractionSystem** permite comunicação simples entre agentes, afetando crenças e emoções.
- **TraditionSystem** registra tradições e rituais, preservando legado emocional.
- **LegacySystem** permite transmitir traços e memórias a novos personagens.
- **CalendarBuilder** cria calendários culturais simbólicos para cada cultura.
- **PhilosophicalIntegrity** avalia a coerência entre ideias geradas.
- **InternalDialectics** coloca ideias em confronto, permitindo sínteses ou reforço.
- **DivineBeing** permite criar deuses com domínio e temperamento.
- **FaithSystem** acompanha devoção, dúvida e heresia.
- **DoctrineEngine** cria dogmas e textos sagrados.
- **ProphecySystem** registra e cumpre profecias.
- **CultSplit** gera cismas e novos cultos a partir de doutrinas.
- **LivingEconomySystem** cria mercados dinâmicos e registra inflação.
- **TradeCareerSystem** permite que IAs sigam carreiras econômicas e fundem guildas.
- **BankingCollapseSystem** gerencia empréstimos e possíveis falências bancárias.
- **EvolvingRaceEconomy** modela estilos de troca que evoluem por raça.
- **HeirloomEconomySystem** registra legados e mutações de modelos econômicos.
- **EconomicLineageVisualizer** exibe genealogias econômicas como árvores.
- **EconomicModelInteractionSystem** documenta fusões e conflitos entre modelos.
- **EconomicCrisisReactionSystem** faz IAs protestarem ou criarem seitas quando a fé é corrompida ou há injustiça.
- **HybridDoctrineSystem** mescla economia e filosofia, criando doutrinas híbridas.
- **PhilosopherLegacySystem** registra filósofos mercantis e suas influências.
- **DoctrinalPoliticalInfluence** registra reformas e dogmas que impactam reinos.
- **DoctrinalLineageSystem** mapeia sucessões filosóficas e heresias.
- **TradeDiplomacySystem** coordena tratados comerciais, confiança e traições entre reinos.
- **Logger** suporta níveis de log e gravação em arquivo.
- **Inventory system** permite que personagens colecionem `Item`s básicos.
- **ReputationSystem** agora registra pontuações numéricas por tag.
- **InteractionVisualizer** mantém um log visual das trocas de diálogos.
- **BranchingDialogue** possui limite de iterações para evitar loops infinitos.
- **NarrativePdfExporter** exporta narrativas simples para arquivos PDF.
- **CalendarBuilder** aceita nomes de meses customizados por cultura.
- **xUnit tests** verificam memórias e resolução de contradições.

## Building

Use the .NET 6 SDK to build the library. Run:

```bash
dotnet build src/UltraWorldAI/UltraWorldAI.csproj
```

Before instantiating any `Person` objects, call `IA.Initialize()` so that runtime settings are loaded from `AIConfig.json`.

### Example Game Loop

The `GameLoop` class provides a very small wrapper to step through multiple `Person` objects on a simple tile map. Create a loop, add characters and run:

```csharp
IA.Initialize();
var loop = new GameLoop(5, 5, true);
var alice = new Person("Alice");
alice.Inventory.Add(new Item("Key"));
loop.AddPerson(alice, 2, 2);
loop.AddPerson(new Person("Bob"), 1, 1);
loop.Run(3);
```

## Testing

Run the unit tests with:

```bash
dotnet test tests/UltraWorldAI.Tests/UltraWorldAI.Tests.csproj
```
