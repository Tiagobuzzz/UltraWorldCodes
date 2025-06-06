# Easter Eggs Programáveis

É possível inserir eventos secretos no jogo definindo ganchos de código. Utilize o módulo `ModScripting` para registrar funções que serão disparadas quando determinadas condições forem atendidas.

Exemplo:

```csharp
ModScripting.RegisterHook("chuva-de-ouro", () => {
    WorldEventQueue.Add("Uma chuva de ouro cai do céu!");
});
```

Os ganchos podem ser ativados em pontos do mapa ou através de combinações de itens pelo jogador.
