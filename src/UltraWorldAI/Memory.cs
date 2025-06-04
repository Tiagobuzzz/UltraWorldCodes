using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;

namespace UltraWorldAI
{
    public class Memory
    {
        public string Summary { get; set; }
        public DateTime Date { get; set; }
        public float Intensity { get; set; }
        public float EmotionalCharge { get; set; }
        public List<string> Keywords { get; set; }
        public string Source { get; set; }

        public Memory()
        {
            Keywords = new List<string>();
        }
    }
}
