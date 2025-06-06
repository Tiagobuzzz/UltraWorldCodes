using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace UltraWorldAI
{
    // ESTRUTURAS E ENUMS
    public enum LifeStage
    {
        Infantil,
        Crianca,
        Adolescente,
        Adulto,
        Idoso
    }

    // --- CONFIGURAÇÕES GLOBAIS (PARAMETRIZAÇÃO DE "MAGIC NUMBERS") ---
    public static class AIConfig
    {
        public const int MaxMemories = 100;
        public const float MemoryDecayRate = 0.01f;
        public const float ForgottenMemoryThreshold = 0.1f;

        public const float EmotionDecayHappiness = -0.01f;
        public const float EmotionDecayFear = -0.05f;
        public const float EmotionDecayAnger = -0.05f;
        public const float EmotionDecayLove = -0.01f;
        public const float EmotionDecaySorrow = -0.02f;
        public const float EmotionDecayCuriosity = -0.01f;
        public const float EmotionDecaySurprise = -0.03f;
        public const float EmotionDecayDisgust = -0.04f;

        public const float TraitMin = 0f;
        public const float TraitMax = 1f;
        public const float EmotionMin = 0f;
        public const float EmotionMax = 1f;
        public const float AffinityMin = 0f;
        public const float AffinityMax = 1f;

        public const float StressIncreasePerContradiction = 0.1f;
        public const float StressReductionPerDefense = 0.05f;
        public const float StressDecayRate = 0.01f;

        public const float MaxStress = 1.0f;
        public const float MinStress = 0.0f;
    }

    public static class AISettings
    {
        public static int MaxMemories = AIConfig.MaxMemories;
        public static float MemoryDecayRate = AIConfig.MemoryDecayRate;
        public static float StressDecayRate = AIConfig.StressDecayRate;
        public static void Load(string path)
        {
            if (!File.Exists(path)) return;
            var json = File.ReadAllText(path);
            var data = JsonSerializer.Deserialize<Dictionary<string, float>>(json);
            if (data == null) return;
            if (data.TryGetValue("MaxMemories", out var mm)) MaxMemories = (int)mm;
            if (data.TryGetValue("MemoryDecayRate", out var mdr)) MemoryDecayRate = mdr;
            if (data.TryGetValue("StressDecayRate", out var sdr)) StressDecayRate = sdr;
        }
    }

    public enum LogLevel { Debug = 0, Info = 1, Warning = 2 }

    public static class Logger
    {
        public static LogLevel Level = LogLevel.Info;
        public static string? FilePath;

        public static void Log(string message, LogLevel level = LogLevel.Info, Exception? ex = null)
        {
            if (level < Level) return;
            var formatted = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}][{level}] {message}";
            if (ex != null) formatted += $" Exception: {ex.Message}";
            Console.WriteLine(formatted);
            if (!string.IsNullOrEmpty(FilePath))
            {
                File.AppendAllText(FilePath!, formatted + Environment.NewLine);
                if (ex != null) File.AppendAllText(FilePath!, ex.StackTrace + Environment.NewLine);
            }
        }
    }
}
