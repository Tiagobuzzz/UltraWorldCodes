using System.Linq;
using UltraWorldAI.Interface;
using Xunit;

public class VisualNarrativeEditorTests
{
    [Fact]
    public void ScenesCanBeEditedAndExported()
    {
        var editor = new VisualNarrativeEditor();
        editor.AddScene("Abertura dramática");
        var mid = editor.AddScene("Conflito interno").Id;
        editor.AddScene("Desfecho");

        editor.MoveScene(mid, 0);
        var json = editor.ExportJson();

        Assert.StartsWith("[", json);
        Assert.Equal(3, editor.Scenes.Count);
        Assert.Equal(mid, editor.Scenes.First().Id);
    }
}
