using System.Collections.Generic;
using UltraWorldAI.Magic;
using Xunit;

public class AlchemyAndMutationSystemTests
{
    [Fact]
    public void CreateRecipeAddsRecipe()
    {
        AlchemyAndMutationSystem.Recipes.Clear();
        AlchemyAndMutationSystem.CreateRecipe("Essencia", new List<string> { "A" }, "B", true);
        Assert.Contains(AlchemyAndMutationSystem.Recipes, r => r.Name == "Essencia");
    }
}
