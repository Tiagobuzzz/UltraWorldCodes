# Possíveis Condições de Corrida

O `GameLoop` executa a atualização dos personagens em paralelo usando `Parallel.For`. Entretanto `GameMap` e a lista interna de atores não são protegidos contra acesso concorrente. Isso pode gerar estados inconsistentes quando múltiplos personagens movem-se ao mesmo tempo.

Para evitar problemas em cenários de grande escala considere:

- Sincronizar o acesso às estruturas de dados do mapa.
- Usar coleções thread-safe ao registrar posições e atores.
- Processar as ações em lotes para reduzir escrituras simultâneas.
