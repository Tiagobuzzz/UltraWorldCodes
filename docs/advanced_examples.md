# Advanced Usage Examples

These examples demonstrate how to combine multiple systems to create richer simulations.

## Custom Narrative

```csharp
IA.Initialize();
var loop = new GameLoop(10, 10);
var hero = new Person("Hero");
hero.AddExperience("saved the village", 0.8f, 0.9f);
loop.AddPerson(hero, 0, 0);
loop.Run(5);
Console.WriteLine(hero.ReflectOnSelf());
```

## Economic Chain Reaction

```csharp
MapFaithEconomyIntegration.RegisterNode("Capital", 500, true, true, "Unity");
MapFaithEconomyIntegration.CreateTradeRoute("Capital", "Outpost", "Iron", 100);
ResourceManagementAI.BalanceWealth();
```

## Introspective Reflection

```csharp
IA.Initialize();
var thinker = new Person("Thinker");
thinker.AddExperience("pondered existence", 0.6f, 0.2f);
thinker.Mind.Introspection.ReflectDeeply();
Console.WriteLine(thinker.ReflectOnSelf());
```


