using System.Collections.Generic;
using UltraWorldAI.Relationships;
using Xunit;

public class EmotionalMarriageSystemTests
{
    [Fact]
    public void FormUnionAddsUnion()
    {
        EmotionalMarriageSystem.Unions.Clear();
        EmotionalMarriageSystem.FormUnion(
            "Kael",
            "Saren",
            "União de almas",
            new List<string> { "Não esconder segredos" },
            true);

        Assert.Contains(EmotionalMarriageSystem.Unions,
            u => u.PartnerA == "Kael" && u.PartnerB == "Saren" && u.InheritedEmotion);
    }
}
