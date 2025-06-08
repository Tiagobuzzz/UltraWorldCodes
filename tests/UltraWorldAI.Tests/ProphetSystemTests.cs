using UltraWorldAI.Religion;
using Xunit;

public class ProphetSystemTests
{
    [Fact]
    public void UpdateProphetStatusTransitionsThroughStages()
    {
        ProphetSystem.AllProphets.Clear();
        ProphetSystem.RegisterProphet("Kael", "Arkhim");
        var prophet = ProphetSystem.AllProphets[0];
        prophet.PersecutionLevel = 6;
        ProphetSystem.UpdateProphetStatus(prophet);
        Assert.Equal(ProphetStatus.Martir, prophet.Status);

        prophet.MiraclesPerformed = 3;
        ProphetSystem.UpdateProphetStatus(prophet);
        Assert.Equal(ProphetStatus.Venerado, prophet.Status);

        prophet.MiraclesPerformed = 6;
        ProphetSystem.UpdateProphetStatus(prophet);
        Assert.Equal(ProphetStatus.Santo, prophet.Status);
    }
}
