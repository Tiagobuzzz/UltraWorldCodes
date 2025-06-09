namespace UltraWorldAI
{
    internal class MemorySystemJsonContext
    {
        public static MemorySystemJsonContext Default { get; } = new();
        public System.Type PersistedState => typeof(MemorySystem.PersistedState);
    }
}
