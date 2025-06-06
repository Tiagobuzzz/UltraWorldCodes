using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
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
        public const float ForgottenMemoryThreshold = 0.05f;

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
        public const float DefaultPersonalityMin = 0.3f;
        public const float DefaultPersonalityMax = 0.7f;
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
        public static float ForgottenMemoryThreshold = AIConfig.ForgottenMemoryThreshold;
        public static float PersonalityMin = AIConfig.DefaultPersonalityMin;
        public static float PersonalityMax = AIConfig.DefaultPersonalityMax;
        public static bool ObserverMode = false;
        public static EventSourcing.IEventStore? EventStore;
        public static void ApplyDefaults()
        {
            MaxMemories = AIConfig.MaxMemories;
            MemoryDecayRate = AIConfig.MemoryDecayRate;
            StressDecayRate = AIConfig.StressDecayRate;
            ForgottenMemoryThreshold = AIConfig.ForgottenMemoryThreshold;
            PersonalityMin = AIConfig.DefaultPersonalityMin;
            PersonalityMax = AIConfig.DefaultPersonalityMax;
        }

        public static void Load(string path)
        {
            ApplyDefaults();
            if (!File.Exists(path)) return;
            var json = File.ReadAllText(path);
            var data = JsonSerializer.Deserialize<Dictionary<string, float>>(json);
            if (data == null) return;
            if (data.TryGetValue("MaxMemories", out var mm)) MaxMemories = (int)mm;
            if (data.TryGetValue("MemoryDecayRate", out var mdr)) MemoryDecayRate = mdr;
            if (data.TryGetValue("StressDecayRate", out var sdr)) StressDecayRate = sdr;
            if (data.TryGetValue("PersonalityMin", out var pmin)) PersonalityMin = pmin;
            if (data.TryGetValue("PersonalityMax", out var pmax)) PersonalityMax = pmax;
            if (data.TryGetValue("ForgottenMemoryThreshold", out var fmt)) ForgottenMemoryThreshold = fmt;
        }

        public static void Reload(string path) => Load(path);
    }

    public enum LogLevel { Debug = 0, Info = 1, Warning = 2, Error = 3 }

    public static class Logger
    {
        public static LogLevel Level = LogLevel.Info;
        public static string? FilePath;
        public static long MaxFileSizeBytes = 5 * 1024 * 1024;
        public static Dictionary<LogLevel, ConsoleColor> LevelColors { get; } = new()
        {
            [LogLevel.Debug] = ConsoleColor.Gray,
            [LogLevel.Info] = ConsoleColor.White,
            [LogLevel.Warning] = ConsoleColor.Yellow,
            [LogLevel.Error] = ConsoleColor.Red
        };

        public static void SetColor(LogLevel level, ConsoleColor color)
        {
            LevelColors[level] = color;
        }

        public static Func<string, LogLevel, bool>? EventFilter;

        public static void Log(string message, LogLevel level = LogLevel.Info, Exception? ex = null)
        {
            if (level < Level) return;
            if (EventFilter != null && !EventFilter.Invoke(message, level)) return;
            var formatted = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}][{level}] {message}";
            if (ex != null) formatted += $" Exception: {ex.Message}";

            var color = Console.ForegroundColor;
            if (LevelColors.TryGetValue(level, out var custom)) Console.ForegroundColor = custom;

            Console.WriteLine(formatted);
            Console.ForegroundColor = color;

            if (!string.IsNullOrEmpty(FilePath))
            {
                try
                {
                    File.AppendAllText(FilePath!, formatted + Environment.NewLine);
                    if (ex != null) File.AppendAllText(FilePath!, ex.StackTrace + Environment.NewLine);
                    var info = new FileInfo(FilePath!);
                    if (info.Length > MaxFileSizeBytes)
                        FilePath = Path.ChangeExtension(FilePath, $"{DateTime.Now:yyyyMMddHHmmss}.log");
                }
                catch (IOException)
                {
                    // Fail silently if log can't be written
                }
            }
        }

        public static async Task LogAsync(string message, LogLevel level = LogLevel.Info, Exception? ex = null)
        {
            if (level < Level) return;
            if (EventFilter != null && !EventFilter.Invoke(message, level)) return;
            var formatted = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}][{level}] {message}";
            if (ex != null) formatted += $" Exception: {ex.Message}";

            var color = Console.ForegroundColor;
            if (LevelColors.TryGetValue(level, out var custom)) Console.ForegroundColor = custom;

            Console.WriteLine(formatted);
            Console.ForegroundColor = color;

            if (!string.IsNullOrEmpty(FilePath))
            {
                try
                {
                    await File.AppendAllTextAsync(FilePath!, formatted + Environment.NewLine);
                    if (ex != null) await File.AppendAllTextAsync(FilePath!, ex.StackTrace + Environment.NewLine);
                    var info = new FileInfo(FilePath!);
                    if (info.Length > MaxFileSizeBytes)
                        FilePath = Path.ChangeExtension(FilePath, $"{DateTime.Now:yyyyMMddHHmmss}.log");
                }
                catch (IOException)
                {
                    // Fail silently if log can't be written
                }
            }
        }

        public static void LogError(string message, Exception? ex = null,
            [System.Runtime.CompilerServices.CallerMemberName] string member = "",
            [System.Runtime.CompilerServices.CallerFilePath] string file = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int line = 0)
        {
            var detail = $"{message} (at {Path.GetFileName(file)}:{line} in {member})";
            Log(detail, LogLevel.Error, ex);
        }
    }
}
