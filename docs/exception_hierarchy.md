# Hierarquia de Exceções

A biblioteca utiliza principalmente exceções do .NET. Os pontos em que exceções são lançadas ou capturadas estão listados abaixo.

## `System.Exception`
- `RaceGeneticCompatibility.CreateHybridGenome` lança quando os genomas têm tamanhos diferentes.
- `IA_RaceLinker.CreateBeing` lança quando a raça solicitada não existe.

## `System.IO.IOException`
- Capturada em operações de persistência da `MemorySystem` e em `NarrativePdfExporter`.
- `CulturePersistence` também captura falhas de leitura ou escrita.

## `System.Net.Http.HttpRequestException`
- Capturada pelo `ExternalAIConnector` ao acessar serviços externos.
