using UltraWorldAI;
using UltraWorldAI.Game;
using Xunit;

public class GameMapTests
{
    [Fact]
    public void PlaceAndMovePersonUpdatesLocation()
    {
        var map = new GameMap(3, 3);
        var person = new Person("Mover");
        map.Place(person, 0, 0);
        map.Move(person, 0, 0, 1, 1);
        Assert.Equal("Tile 1,1", person.Location.RegionName);
    }
}
