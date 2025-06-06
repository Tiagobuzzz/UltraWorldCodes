using System;
using System.Collections.Generic;

namespace UltraWorldAI.Politics;

public class ChivalricOrder
{
    public string Name { get; set; } = string.Empty;
    public string Founder { get; set; } = string.Empty;
    public string Purpose { get; set; } = string.Empty; // "Proteger linhagem", "Caçar bruxas", "Manter paz"
    public List<string> Members { get; } = new();
}

public static class ChivalricOrderSystem
{
    public static List<ChivalricOrder> Orders { get; } = new();

    public static void CreateOrder(string name, string founder, string purpose)
    {
        Orders.Add(new ChivalricOrder
        {
            Name = name,
            Founder = founder,
            Purpose = purpose
        });

        Console.WriteLine($"🩸 Ordem fundada: {name} por {founder} | Missão: {purpose}");
    }

    public static void AddMember(string orderName, string member)
    {
        var o = Orders.Find(x => x.Name == orderName);
        if (o != null)
        {
            o.Members.Add(member);
            Console.WriteLine($"⚔️ {member} juntou-se à ordem {orderName}");
        }
    }

    public static void PrintOrders()
    {
        foreach (var o in Orders)
        {
            Console.WriteLine($"\n🏅 {o.Name} | Fundador: {o.Founder} | Missão: {o.Purpose}");
            Console.WriteLine($"• Membros: {string.Join(", ", o.Members)}");
        }
    }
}
