using UltraWorldAI.Module15;
using Xunit;

public class LiteraryExpressionSystemTests
{
    [Fact]
    public void CreateWorkAddsLiteraryWork()
    {
        LiteraryExpressionSystem.Works.Clear();
        LiteraryExpressionSystem.CreateWork("Ana", "Poesia", "Amor", "Minimalista");
        Assert.Contains(LiteraryExpressionSystem.Works, w => w.Author == "Ana" && w.Genre == "Poesia" && w.Style == "Minimalista");
    }
}
