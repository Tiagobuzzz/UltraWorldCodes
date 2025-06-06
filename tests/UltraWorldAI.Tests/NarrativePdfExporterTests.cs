using UltraWorldAI.Visualization;
using System.IO;
using Xunit;

public class NarrativePdfExporterTests
{
    [Fact]
    public void ExportCreatesPdfFile()
    {
        var path = Path.GetTempFileName();
        NarrativePdfExporter.Export("Test narrative", path);
        var content = File.ReadAllText(path);
        Assert.Contains("%PDF-1.4", content);
    }
}
