namespace UltraWorldAI.Interface;

public enum CameraMode
{
    FirstPerson,
    ThirdPerson,
    Overhead
}

public class WorldCamera
{
    public CameraMode Mode { get; private set; }

    public WorldCamera(CameraMode mode = CameraMode.FirstPerson)
    {
        Mode = mode;
    }

    public void CycleMode()
    {
        Mode = Mode switch
        {
            CameraMode.FirstPerson => CameraMode.ThirdPerson,
            CameraMode.ThirdPerson => CameraMode.Overhead,
            _ => CameraMode.FirstPerson
        };
    }

    public string Describe() => $"Modo de câmera: {Mode}";
}
