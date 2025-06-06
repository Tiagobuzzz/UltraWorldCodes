# Ordem de Inicialização dos Módulos

1. **IA.Initialize** – Carrega as configurações definidas em `AIConfig.json` ou aplica os valores padrão de `AIConfig`.
2. **GameLoop** – Cria o mapa de jogo e define modos de exibição e observação.
3. **Person** – Cada personagem é instanciado com sistemas internos como memória e crenças.
4. **Sub-sistemas** – Durante a atualização, módulos como `MemorySystem`, `BeliefSystem` e `DoctrineSystem` são executados nessa ordem.

A sequência garante que todas as dependências estejam prontas antes que o loop principal comece.
