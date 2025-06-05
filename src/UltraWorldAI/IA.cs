using System;

using System.Collections.Generic;

namespace UltraWorldAI
{
    // This file is kept for compatibility with older revisions where
    // all classes were defined in a single source file named `IA.cs`.
    // The AI implementation has been refactored and each subsystem now
    // resides in its own file inside the `src/UltraWorldAI/` directory.
    //
    // Classes such as `Person`, `Mind`, `MemorySystem`, etc. can be found
    // in their respective files. This wrapper exposes a simple entry
    // point for initializing runtime settings.
    public static class IA
    {
        public static void Initialize(string configPath = "AIConfig.json")
        {
            AISettings.Load(configPath);
        }
    }
