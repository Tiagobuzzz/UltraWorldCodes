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
    }
}
