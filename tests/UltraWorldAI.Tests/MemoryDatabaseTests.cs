using System;
using System.Collections.Generic;
using System.IO;
using UltraWorldAI;
using UltraWorldAI.Persistence;
using Xunit;

public class MemoryDatabaseTests
{
    [Fact]
    public void SaveAndLoadRoundTrip()
    {
        var path = Path.GetTempFileName();
        var connection = $"Data Source={path}";
        try
        {
            var memories = new List<Memory>
            {
                new Memory
                {
                    Summary = "evento",
                    Date = DateTime.Now,
                    Intensity = 0.5f,
                    EmotionalCharge = 0.1f,
                    Source = "test",
                    Keywords = new(),
                    Emotion = string.Empty
                }
            };
            MemoryDatabase.Save(connection, memories);
            var loaded = MemoryDatabase.Load(connection);
            Assert.Single(loaded);
            Assert.Equal("evento", loaded[0].Summary);
        }
        finally
        {
            File.Delete(path);
        }
    }
}
