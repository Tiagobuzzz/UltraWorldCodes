using System;

namespace UltraWorldAI.Interface;

/// <summary>
/// Simple console interface to adjust AI settings at runtime.
/// </summary>
public static class ConfigUI
{
    public static void Show()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("== AI Settings ==");
            Console.WriteLine($"1) Max memories: {AISettings.MaxMemories}");
            Console.WriteLine($"2) Memory decay rate: {AISettings.MemoryDecayRate}");
            Console.WriteLine($"3) Stress decay rate: {AISettings.StressDecayRate}");
            Console.WriteLine($"4) Forget threshold: {AISettings.ForgottenMemoryThreshold}");
            Console.WriteLine("0) Save and exit");
            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.Write("New value: ");
                    if (int.TryParse(Console.ReadLine(), out var mm))
                        AISettings.MaxMemories = mm;
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Console.Write("New value: ");
                    if (float.TryParse(Console.ReadLine(), out var mdr))
                        AISettings.MemoryDecayRate = mdr;
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    Console.Write("New value: ");
                    if (float.TryParse(Console.ReadLine(), out var sdr))
                        AISettings.StressDecayRate = sdr;
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    Console.Write("New value: ");
                    if (float.TryParse(Console.ReadLine(), out var fth))
                        AISettings.ForgottenMemoryThreshold = fth;
                    break;
                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                case ConsoleKey.Escape:
                    running = false;
                    break;
            }
            Console.WriteLine();
        }
        Save("AIConfig.json");
    }

    public static void Save(string path)
    {
        var json = System.Text.Json.JsonSerializer.Serialize(new System.Collections.Generic.Dictionary<string, float>
        {
            ["MaxMemories"] = AISettings.MaxMemories,
            ["MemoryDecayRate"] = AISettings.MemoryDecayRate,
            ["StressDecayRate"] = AISettings.StressDecayRate,
            ["PersonalityMin"] = AISettings.PersonalityMin,
            ["PersonalityMax"] = AISettings.PersonalityMax,
            ["ForgottenMemoryThreshold"] = AISettings.ForgottenMemoryThreshold
        }, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
        System.IO.File.WriteAllText(path, json);
    }
}
