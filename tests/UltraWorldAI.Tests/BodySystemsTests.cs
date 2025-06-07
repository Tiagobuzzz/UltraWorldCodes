using UltraWorldAI.Module13;
using Xunit;

public class BodySystemsTests
{
    [Fact]
    public void RegisterBodyCreatesProfile()
    {
        BodyHealthSystem.Bodies.Clear();
        BodyHealthSystem.RegisterBody("Kael");
        Assert.Contains(BodyHealthSystem.Bodies, b => b.Name == "Kael");
    }

    [Fact]
    public void DamageOrganReducesValue()
    {
        BodyHealthSystem.Bodies.Clear();
        BodyHealthSystem.RegisterBody("Kael");
        BodyHealthSystem.DamageOrgan("Kael", "Olhos", 0.3f);
        var body = BodyHealthSystem.Bodies.Find(b => b.Name == "Kael");
        Assert.True(body!.Organs["Olhos"] < 1.0f);
    }

    [Fact]
    public void AddMethodAddsHealing()
    {
        HealingAndMedicineSystem.Methods.Clear();
        HealingAndMedicineSystem.AddMethod("Elfos", "Infusao", "Cegueira", 0.5f);
        Assert.Contains(HealingAndMedicineSystem.Methods, m => m.Type == "Infusao");
    }

    [Fact]
    public void AddModificationAddsMod()
    {
        BodyModificationSystem.Modifications.Clear();
        BodyModificationSystem.AddModification("Runas", "Implante", "Visao", "Ordem", false);
        Assert.Contains(BodyModificationSystem.Modifications, m => m.Name == "Runas");
    }
}
