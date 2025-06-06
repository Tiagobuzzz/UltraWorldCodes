using UltraWorldAI;
using UltraWorldAI.Visualization;
using Xunit;

public class WebDataExporterTests
{
    [Fact]
    public void ExportPersonReturnsJsonWithName()
    {
        var person = new Person("Exporter");
        person.AddExperience("teste", 0.5f);

        var json = WebDataExporter.ExportPerson(person);
        Assert.Contains("Exporter", json);
        Assert.Contains("memories", json);
    }
}
