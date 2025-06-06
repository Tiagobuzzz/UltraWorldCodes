# Monitoramento de Desempenho

Use o script `run-profiling.sh` para gerar relatórios rápidos de uso de CPU e memória.
Ele utiliza `dotnet-counters` e grava os resultados em `cpu_mem_report.csv`.

Para analisar possíveis gargalos de I/O em disco recomenda-se ferramentas como `iotop` ou `iostat` durante execuções prolongadas do jogo.
