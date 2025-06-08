using System;
using System.Collections.Generic;

namespace UltraWorldAI.Religion;

public enum ProphetStage
{
    Prophet,
    Martyr,
    Saint
}

public class ProphetRecord
{
    public string Name { get; set; } = string.Empty;
    public ProphetStage Stage { get; set; } = ProphetStage.Prophet;
    public float Reverence { get; set; }
}

public static class ProphetEvolutionSystem
{
    private static readonly Dictionary<string, ProphetRecord> _records = new();

    public static ProphetRecord Register(string name)
    {
        var record = new ProphetRecord { Name = name };
        _records[name] = record;
        return record;
    }

    public static void RecordMartyrdom(string name)
    {
        if (!_records.TryGetValue(name, out var record))
        {
            record = Register(name);
        }

        record.Stage = ProphetStage.Martyr;
        record.Reverence = Math.Max(record.Reverence, 0.5f);
        Console.WriteLine($"\uD83D\uDD4A️ {name} tornou-se m\u00e1rtir.");
    }

    public static void AddReverence(string name, float amount)
    {
        if (_records.TryGetValue(name, out var record))
        {
            record.Reverence = Math.Clamp(record.Reverence + amount, 0f, 1f);
            if (record.Stage == ProphetStage.Martyr && record.Reverence >= 0.8f)
            {
                record.Stage = ProphetStage.Saint;
                Console.WriteLine($"\u2728 {name} foi canonizado.");
            }
        }
    }

    public static ProphetStage? GetStage(string name)
    {
        return _records.TryGetValue(name, out var record) ? record.Stage : null;
    }
}

