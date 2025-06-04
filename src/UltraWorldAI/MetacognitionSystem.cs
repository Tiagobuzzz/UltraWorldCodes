using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;

namespace UltraWorldAI
{
    public class MetacognitionSystem
    {
        private Person _person;
        public List<string> SelfImage { get; private set; } = new List<string>();

        public MetacognitionSystem(Person person)
        {
            _person = person;
            SelfImage.Add("paciente");
            SelfImage.Add("sociável");
            SelfImage.Add("justo");
            SelfImage.Add("curioso");
        }

        public void AddToSelfImage(string aspect)
        {
            if (!SelfImage.Contains(aspect))
            {
                SelfImage.Add(aspect);
                Logger.Log($"[Metacognition] {_person.Name}'s self-image now includes: {aspect}");
            }
        }

        public void RemoveFromSelfImage(string aspect)
        {
            if (SelfImage.Remove(aspect))
            {
                Logger.Log($"[Metacognition] {_person.Name}'s self-image no longer includes: {aspect}");
            }
        }
    }
}
