using UltraWorldAI.Health;
using Xunit;

public class PublicHealthAITests
{
    [Fact]
    public void AdmitRespectsCapacity()
    {
        PublicHealthAI.Hospitals.Clear();
        PublicHealthAI.RegisterHospital("R1", 100);
        PublicHealthAI.Admit("R1", 120);
        Assert.Equal(100, PublicHealthAI.GetLoad("R1"));
    }
}
