# UltraWorldCodes

[![Build Status](https://github.com/example/UltraWorldCodes/actions/workflows/dotnet.yml/badge.svg)](https://github.com/example/UltraWorldCodes/actions)
[![Coverage Status](https://img.shields.io/badge/coverage-auto-brightgreen)](docs/code_quality_metrics.md)
[![Maintainability](https://img.shields.io/badge/maintainability-A-brightgreen)](docs/code_quality_metrics.md)
[![License: Proprietary](https://img.shields.io/badge/license-Proprietary-lightgrey)](LICENSE)

This repository contains the game code and the AI module. The AI logic is
split across several files under `src/UltraWorldAI/`, each implementing
interlinked systems that model memory, beliefs, personality, emotions and more.

## Dependencies

- [.NET 8 SDK](https://dotnet.microsoft.com/) for building and running the project
- [Microsoft.Data.Sqlite](https://www.nuget.org/packages/Microsoft.Data.Sqlite) for local storage
- [xUnit](https://xunit.net/) for unit tests

For help and community discussions join our [support channel](https://example.com/discord).

## Unity Integration

See [docs/unity_integration.md](docs/unity_integration.md) for instructions on building a DLL and importing it into a Unity project.

## Unreal Engine Integration

Projects that rely on C# plugins for Unreal Engine can follow the steps in [docs/unreal_integration.md](docs/unreal_integration.md) to use the library with Unreal.

## Versioning

This project follows [Semantic Versioning](https://semver.org/). Public releases
use the `MAJOR.MINOR.PATCH` scheme where breaking changes increment the major
version, new features increment the minor version and bug fixes increment the
patch number.
Release artifacts are tagged in the repository using the same version number
(for example `v1.2.0`).

To generate coverage reports use:

```bash
dotnet test --collect:"XPlat Code Coverage"
```

## Structure
- The `src/UltraWorldAI/` directory contains the implementation of all
  subsystems such as memory, beliefs, metacognition and the narrative engine.
- `AIConfig.json` can override some runtime parameters (like `MaxMemories`).
  Example:

  ```json
  {
    "MaxMemories": 150,
    "MemoryDecayRate": 0.01,
    "StressDecayRate": 0.01,
    "PersonalityMin": 0.3,
    "PersonalityMax": 0.7
  }
  ```

Sample culture data for quick experiments is available in
[`docs/culture_examples.json`](docs/culture_examples.json).

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
- **CulturalAdaptationSystem** ajusta comportamentos para respeitar costumes locais.
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
- **ResourceManagementAI** equilibra consumo e riqueza entre assentamentos.
- **InternationalEspionageSystem** avalia riscos em operações secretas.
- **BlockchainLedger** grava eventos econômicos em cadeia imutável.
- **DoctrineCustomizer** permite editar doutrinas em detalhe.
- **AdaptivePlayStyleAI** ajusta estratégias conforme jogadas passadas.
- **DoctrinalPoliticalInfluence** registra reformas e dogmas que impactam reinos.
- **DoctrinalLineageSystem** mapeia sucessões filosóficas e heresias.
- **TradeDiplomacySystem** coordena tratados comerciais, confiança e traições entre reinos.
- **MaritimeTradeSystem** gerencia portos e rotas de comércio naval.
- **RuinGenerator** e **ArchaeologySystem** criam ruínas e possibilitam exploração arqueológica.
- **LifeCycleSystem** acompanha nascimento, envelhecimento e morte dos personagens.
- **HistoricalInspirationSystem** fornece eventos reais para inspiração narrativa.
- **NarrativeWebPlatform** permite compartilhar narrativas geradas via HTTP.
- **Logger** suporta níveis de log e gravação em arquivo.
- **Logger** permite personalizar cores de saída e grava logs de forma assíncrona.
- **Inventory system** permite que personagens colecionem `Item`s básicos.
- **ReputationSystem** agora registra pontuações numéricas por tag.
- **InteractionVisualizer** mantém um log visual das trocas de diálogos.
- **BranchingDialogue** possui limite de iterações para evitar loops infinitos.
- **NarrativePdfExporter** exporta narrativas simples para arquivos PDF.
- **CalendarBuilder** aceita nomes de meses customizados por cultura.
- **ScientificDiscoveryGenerator** cria eventos aleatórios de descobertas científicas.
- **CulturalEntertainmentSystem** mantém mídias de entretenimento por cultura.
- **LanguageEvolutionSystem** faz evoluir dialetos ao longo do tempo.
- **LanguageHeritageSystem** preserva idiomas como herança cultural e lamenta sua perda.
- **ImperialLinguisticConflictSystem** registra disputas de idioma dentro de impérios.
- **NeologismGenerator** permite que IAs criem novas palavras.
- **AirTradeSystem** suporta rotas comerciais aéreas.
- **ModScriptEngine** possibilita scripts externos de mods.
- **ExternalAIConnector** integra serviços de IA de terceiros.
- **ClimateForecastAI** prevê padrões climáticos com base em eventos passados.
- **RevolutionPatternDetector** analisa causas recorrentes de revoluções.
- **EnergyGrid** gerencia fontes e consumo de energia.
- **ParanormalEventGenerator** cria eventos científicos paranormais.
- **WorldCamera** oferece múltiplos modos de visualização do mundo.
- **OralTraditionRecorder** registra histórias contadas verbalmente.
- **LostTechnologyRegistry** acompanha tecnologias perdidas e redescobertas.
- **RealTimeStatsServer** disponibiliza estatísticas ao vivo via HTTP.
- **UltraWorldObscura** reúne locais proibidos, ressonâncias mentais,
  estruturas vivas e corredores não euclidianos.
- **Muitos NPCs** podem aumentar bastante o uso de memória e CPU; meça com os benchmarks antes de ampliar a escala.
- Minimum hardware requirements are listed in [docs/hardware_requirements.md](docs/hardware_requirements.md).
- **xUnit tests** verificam memórias e resolução de contradições.

## Building

Use the .NET 8 SDK to build the library. Run:

```bash
dotnet build src/UltraWorldAI/UltraWorldAI.csproj
```

Before instantiating any `Person` objects, call `IA.Initialize()` so that runtime settings are loaded from `AIConfig.json`.

### Example Game Loop

The `GameLoop` class provides a very small wrapper to step through multiple `Person` objects on a simple tile map. Use `PrehistoricWorldInitializer` to begin with no knowledge in a pre-stone age era and then create a loop:

```csharp
IA.Initialize();
var deity = new Person("Deity");
PrehistoricWorldInitializer.Initialize(deity);
var loop = new GameLoop(5, 5, true);
loop.AddPerson(deity, 2, 2);
loop.AddPerson(new Person("Bob"), 1, 1);
loop.Run(3);
```

Enable verbose information during simulations by toggling the `DebugMode` property on `SimulationSystem`.

## Benchmarking

Benchmarks help estimate the cost of AI loops. Build and run the benchmark project with:

```bash
dotnet run -c Release -p benchmarks/Benchmarks.csproj
```

Typical runs on a mid-range machine process around 5 turns in under 50ms,
allowing thousands of iterations per second for large simulations.

## Testing

Run the unit tests with:

```bash
./run-tests.sh
```

Cyclomatic complexity metrics can be generated with:

```bash
./run-metrics.sh
```
See [docs/code_quality_metrics.md](docs/code_quality_metrics.md) for more details.

## Diagrams

An overview of the update cycle is provided as a Mermaid sequence diagram in [docs/sequence_diagram.md](docs/sequence_diagram.md).

Additional usage examples can be found in [docs/advanced_examples.md](docs/advanced_examples.md).
Usage scenarios for each subsystem are summarized in [docs/subsystem_usage_scenarios.md](docs/subsystem_usage_scenarios.md).
Example assets are available under [assets/examples](assets/examples).
Video walkthroughs are listed in [docs/video_tutorials.md](docs/video_tutorials.md).
UI mockups can be viewed in [docs/ui_mockups.md](docs/ui_mockups.md).
Guidelines for scaling worlds to very large maps are documented in [docs/scaling_large_maps.md](docs/scaling_large_maps.md).
Examples of fulfilled prophecies are listed in [docs/fulfilled_prophecies.md](docs/fulfilled_prophecies.md).
The effect of doctrines on personality traits is described in [docs/doctrine_impact.md](docs/doctrine_impact.md).
The module startup order is detailed in [docs/module_startup_order.md](docs/module_startup_order.md).
High level diagrams can be found in [docs/uml_overview.md](docs/uml_overview.md).
The overall architecture is summarised in [docs/architecture_overview.md](docs/architecture_overview.md).
Technology integration is documented in [docs/technology_integration.md](docs/technology_integration.md).
Examples of mod integration can be found in [docs/mod_integration_examples.md](docs/mod_integration_examples.md).
The technology inheritance system is described in [docs/tech_inheritance.md](docs/tech_inheritance.md).
Known simulation issues are listed in [docs/known_simulation_failures.md](docs/known_simulation_failures.md).
NPC hiring and training guidelines are described in [docs/npc_hiring_training.md](docs/npc_hiring_training.md).

## Contributing

Contributions are welcome! A full guide is available in [CONTRIBUTING.md](CONTRIBUTING.md). Key points:

- Use the .NET 8 SDK and follow C# 10 style conventions.
- Keep the code modular under `src/UltraWorldAI` and format the code using `dotnet format`.
- Configure git to use the pre-commit hook under `.githooks` to enforce formatting.
- Run `./run-tests.sh` before submitting a pull request.
- Keep comments in the present tense to maintain consistency.
- Add or update unit tests whenever you introduce new functionality.
- Document any public APIs you create or modify in the `docs` folder.
- Prefer the built-in `Logger` and use its asynchronous methods when logging to disk.

## License

UltraWorldCodes is distributed under a proprietary license. See [LICENSE](LICENSE) for full terms. Collaboration on the code is permitted only with prior written authorization from the owner.

## Performance Hints

- Execute `run-profiling.sh` para obter relatórios rápidos de CPU e memória.
- Rode o jogo em build *Release* para medições mais realistas.

## FAQ

**Q: Em quais sistemas operacionais o jogo roda?**

R: O código é multiplataforma e executa em Windows, Linux e macOS usando o .NET 8.

**Q: Preciso chamar `IA.Initialize()` antes do jogo?**

R: Sim. Isso carrega configurações e é necessário antes de criar `Person` ou `GameLoop`.
