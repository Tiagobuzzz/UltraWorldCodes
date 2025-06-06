using System.Linq;
using UltraWorldAI.Politics;
using Xunit;

public class GovernmentFormSystemTests
{
    [Fact]
    public void SetsGovernmentForm()
    {
        GovernmentFormSystem.Forms.Clear();
        GovernmentFormSystem.SetGovernment("Reino de Kael", "Teocracia", "Profecia", "Escolhido");
        Assert.Contains(GovernmentFormSystem.Forms, g => g.Kingdom == "Reino de Kael" && g.Type == "Teocracia");
    }
}
