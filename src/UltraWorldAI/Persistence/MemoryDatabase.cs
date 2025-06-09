using System;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace UltraWorldAI.Persistence;

public static class MemoryDatabase
{
    public static void Save(string connection, List<Memory> memories)
    {
        using var db = new SqliteConnection(connection);
        db.Open();
        var cmd = db.CreateCommand();
        cmd.CommandText = "CREATE TABLE IF NOT EXISTS Memories(Summary TEXT,Date TEXT,Intensity REAL,Emotion REAL,Source TEXT)";
        cmd.ExecuteNonQuery();
        using var tx = db.BeginTransaction();
        cmd.Transaction = tx;
        foreach (var m in memories)
        {
            cmd.CommandText = "INSERT INTO Memories VALUES(@s,@d,@i,@e,@src)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@s", m.Summary);
            cmd.Parameters.AddWithValue("@d", m.Date.ToString("o"));
            cmd.Parameters.AddWithValue("@i", m.Intensity);
            cmd.Parameters.AddWithValue("@e", m.EmotionalCharge);
            cmd.Parameters.AddWithValue("@src", m.Source);
            cmd.ExecuteNonQuery();
        }
        tx.Commit();
    }

    public static List<Memory> Load(string connection)
    {
        var list = new List<Memory>();
        using var db = new SqliteConnection(connection);
        db.Open();
        var cmd = db.CreateCommand();
        cmd.CommandText = "SELECT Summary,Date,Intensity,Emotion,Source FROM Memories";
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new Memory
            {
                Summary = reader.GetString(0),
                Date = DateTime.Parse(reader.GetString(1)),
                Intensity = (float)reader.GetDouble(2),
                EmotionalCharge = (float)reader.GetDouble(3),
                Source = reader.GetString(4),
                Keywords = new(),
                Emotion = string.Empty
            });
        }
        return list;
    }
}
