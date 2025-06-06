using UltraWorldAI;
using UltraWorldAI.Game;
using Xunit;

public class GameMapRenderTests
{
    [Fact]
    public void RenderShowsOccupants()
    {
        var map = new GameMap(2, 1);
        var p = new Person("A");
        map.Place(p, 0, 0);
        var view = map.Render();
        Assert.StartsWith("O", view.Trim());
    }
}
