using System.Collections.Generic;
using UltraWorldAI.Module15;
using Xunit;

public class PersonalStyleSystemTests
{
    [Fact]
    public void DefineStyleStoresProfile()
    {
        PersonalStyleSystem.Styles.Clear();
        PersonalStyleSystem.DefineStyle("Ana", new List<string> { "Brilho" }, "Elegante");
        Assert.Contains(PersonalStyleSystem.Styles, s => s.Name == "Ana" && s.DominantMood == "Elegante");
    }
}
