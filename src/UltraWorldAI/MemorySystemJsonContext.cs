using System.Text.Json.Serialization;

namespace UltraWorldAI;

[JsonSerializable(typeof(MemorySystem.PersistedState))]
internal partial class MemorySystemJsonContext : JsonSerializerContext
{
}
