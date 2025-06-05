using UltraWorldAI.Society;
using Xunit;

public class TechCivilizationStylesTests
{
    [Fact]
    public void CreateStyleAddsStyle()
    {
        TechCivilizationStyles.Styles.Clear();
        var style = TechCivilizationStyles.CreateStyle("controle", "IA");
        Assert.Single(TechCivilizationStyles.Styles);
        Assert.Equal("Civilizacao de IA", style.Name);
    }
}
