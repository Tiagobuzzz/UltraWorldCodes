using System;
using System.Collections.Generic;

namespace UltraWorldAI.Magic;

public class AlchemyRecipe
{
    public string Name = string.Empty;
    public List<string> Ingredients = new();
    public string Result = string.Empty; // "Elixir de Visão Cósmica", "Pele de Pedra"
    public bool CausesMutation;
}

public static class AlchemyAndMutationSystem
{
    public static List<AlchemyRecipe> Recipes { get; } = new();

    public static void CreateRecipe(string name, List<string> ingredients, string result, bool mutation)
    {
        Recipes.Add(new AlchemyRecipe
        {
            Name = name,
            Ingredients = ingredients,
            Result = result,
            CausesMutation = mutation
        });

        Console.WriteLine($"\uD83E\uDDEA Receita alqu\u00EDmica: {name} | Resultado: {result} | Muta\u00E7\u00E3o: {mutation}");
    }

    public static void PrintRecipes()
    {
        foreach (var r in Recipes)
            Console.WriteLine($"\n\uD83E\uDD9C {r.Name} | Ingredientes: {string.Join(", ", r.Ingredients)} | Resultado: {r.Result} | Muta\u00E7\u00E3o: {r.CausesMutation}");
    }
}
