# Subsystem Usage Scenarios

Este documento resume como utilizar rapidamente alguns dos subsistemas principais.

## MemorySystem
Registra memórias com `AddMemory` e reduz sua intensidade com `UpdateMemoryDecay`.

## BeliefArchitecture
Adiciona ou reforça crenças via `AddBelief` e enfraquece com `DecayBeliefs`.

## PersonalitySystem
Permite ler ou ajustar traços de personalidade usando `GetTrait` e `AdjustTrait`.

## ProphecySystem
Crie profecias com `Create` e chame `ApplySelfFulfillment` a cada ciclo para verificar se eventos ou memórias as cumpriram.

## TutorialSystem
Fornece passos guiados; `RunInteractive` exibe cada instrução e espera a entrada do usuário.

## Persistence
Tanto `CulturePersistence` quanto `MemoryDatabase` possibilitam salvar e restaurar estados do jogo.
