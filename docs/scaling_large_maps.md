# Escalando para Mapas Grandes

Mapas com milhares de tiles exigem cuidados para manter a performance.

- Prefira dividir o mundo em "chunks" carregados sob demanda.
- Use estruturas esparsas para tiles vazios.
- Meça o custo de processamento com os benchmarks antes de aumentar o tamanho.
- Avalie simplificar a IA ou reduzir a frequência de atualização dos NPCs em mapas extensos.
