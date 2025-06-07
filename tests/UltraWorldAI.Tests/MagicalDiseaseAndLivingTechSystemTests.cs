using UltraWorldAI.Module13;
using Xunit;

public class MagicalDiseaseAndLivingTechSystemTests
{
    [Fact]
    public void AddDiseaseStoresDisease()
    {
        MagicalDiseaseSystem.Diseases.Clear();
        MagicalDiseaseSystem.AddDisease("Choro", "Plano", "Brilho", 0.3f, true);
        Assert.Contains(MagicalDiseaseSystem.Diseases, d => d.Name == "Choro");
    }

    [Fact]
    public void AddDeviceStoresDevice()
    {
        LivingMedicalTechSystem.Devices.Clear();
        LivingMedicalTechSystem.AddDevice("Cora\u00e7\u00e3o", "Regen", "\u00d3rg\u00e3o", true);
        Assert.Contains(LivingMedicalTechSystem.Devices, d => d.Name == "Cora\u00e7\u00e3o");
    }
}
