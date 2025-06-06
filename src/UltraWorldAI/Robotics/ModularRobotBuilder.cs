using System.Collections.Generic;

namespace UltraWorldAI.Robotics;

public class Robot
{
    public string Name { get; set; } = string.Empty;
    public List<string> Modules { get; } = new();
}

/// <summary>
/// Allows modular construction of robots and machines.
/// </summary>
public static class ModularRobotBuilder
{
    public static Robot Create(string name, List<string> modules)
    {
        var r = new Robot { Name = name };
        r.Modules.AddRange(modules);
        return r;
    }
}
