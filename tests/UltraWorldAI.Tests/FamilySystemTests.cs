using UltraWorldAI.Kinship;
using Xunit;

public class FamilySystemTests
{
    [Fact]
    public void RegisterAndAdoptSetsAdopter()
    {
        FamilySystem.Families.Clear();
        FamilySystem.RegisterMember("Child", "P1", "P2");
        FamilySystem.Adopt("Child", "Adopter");
        Assert.Equal("Adopter", FamilySystem.Families["Child"].AdoptedBy);
    }
}
