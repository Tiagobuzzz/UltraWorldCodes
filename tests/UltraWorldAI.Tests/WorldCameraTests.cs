using UltraWorldAI.Interface;
using Xunit;

public class WorldCameraTests
{
    [Fact]
    public void CycleModeChangesMode()
    {
        var cam = new WorldCamera();
        cam.CycleMode();
        Assert.Equal(CameraMode.ThirdPerson, cam.Mode);
    }
}
