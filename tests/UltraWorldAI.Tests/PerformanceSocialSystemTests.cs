using System.Collections.Generic;
using UltraWorldAI.Module15;
using Xunit;

public class PerformanceSocialSystemTests
{
    [Fact]
    public void CreatePerformanceAddsGroup()
    {
        PerformanceSocialSystem.Groups.Clear();
        PerformanceSocialSystem.CreatePerformance("Lamentos", new List<string> {"A", "B"}, "Coro", "Invocar");
        Assert.Contains(PerformanceSocialSystem.Groups, g => g.Name == "Lamentos" && g.Members.Contains("A") && g.Form == "Coro" && g.Purpose == "Invocar");
    }
}
