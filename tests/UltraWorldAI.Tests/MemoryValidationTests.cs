using System.IO;
using UltraWorldAI;
using Xunit;

public class MemoryValidationTests
{
    [Fact]
    public void ValidateSaveFileReturnsTrueForValidFile()
    {
        var memSys = new MemorySystem();
        memSys.AddMemory("evento", 0.5f);
        var tmp = Path.GetTempFileName();
        memSys.SaveMemories(tmp);
        Assert.True(memSys.ValidateSaveFile(tmp));
        File.Delete(tmp);
    }

    [Fact]
    public void ValidateSaveFileReturnsFalseForCorruptFile()
    {
        var memSys = new MemorySystem();
        var tmp = Path.GetTempFileName();
        File.WriteAllText(tmp, "invalid");
        Assert.False(memSys.ValidateSaveFile(tmp));
        File.Delete(tmp);
    }
}
