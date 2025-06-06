using System.Collections.Generic;

namespace UltraWorldAI
{
    public class SocialRelationship
    {
        public string Name { get; set; } = string.Empty;
        public float Affinity { get; set; }
    }

    public class SocialSystem
    {
        public List<SocialRelationship> Relationships { get; } = new();

        public void ApplyReward(string name, float value)
        {
            var rel = Relationships.Find(r => r.Name == name);
            if (rel == null)
            {
                rel = new SocialRelationship { Name = name, Affinity = 0f };
                Relationships.Add(rel);
            }
            rel.Affinity += value;
        }

        public void ApplyPunishment(string name, float value)
        {
            ApplyReward(name, -value);
        }
    }
}
