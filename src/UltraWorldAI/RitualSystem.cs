using System;
using System.Collections.Generic;

namespace UltraWorldAI
{
    public class RitualGesture
    {
        public string Name { get; set; } = string.Empty;
        public bool IsSacred { get; set; }
    }

    public class RitualSystem
    {
        public List<RitualGesture> KnownGestures { get; } = new();

        public void PerformLifeTransition(string phase, Person performer)
        {
            string msg = $"{performer.Name} realizou ritual de transi\u00e7\u00e3o: {phase}.";
            performer.Mind.Memory.AddMemory(msg, 0.4f, 0.2f, new() { "ritual" }, "ritual");
            Console.WriteLine(msg);
        }
    }
}
