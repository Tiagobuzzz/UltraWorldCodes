namespace UltraWorldAI.Kinship;

public class FamilyMember
{
    public string Name = string.Empty;
    public string Parent1 = string.Empty;
    public string Parent2 = string.Empty;
    public List<string> Children = new();
    public List<string> Siblings = new();
    public string AdoptedBy = string.Empty;
}

public static class FamilySystem
{
    public static Dictionary<string, FamilyMember> Families = new();

    public static void RegisterMember(string name, string parent1, string parent2)
    {
        var member = new FamilyMember { Name = name, Parent1 = parent1, Parent2 = parent2 };
        Families[name] = member;
        if (Families.ContainsKey(parent1)) Families[parent1].Children.Add(name);
        if (Families.ContainsKey(parent2)) Families[parent2].Children.Add(name);
        Console.WriteLine($"👨‍👩‍👧 Família criada: {name} | Pais: {parent1}, {parent2}");
    }

    public static void Adopt(string child, string adopter)
    {
        if (Families.ContainsKey(child))
            Families[child].AdoptedBy = adopter;
        Console.WriteLine($"🫂 {adopter} adotou {child}");
    }
}
