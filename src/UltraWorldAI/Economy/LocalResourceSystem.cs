using System;
using System.Collections.Generic;

namespace UltraWorldAI.Economy;

public class ResourceNode
{
    public string Region { get; set; } = string.Empty;
    public string ResourceType { get; set; } = string.Empty; // "Grãos", "Mineral", "Relíquia", "Magia", etc.
    public int Quantity { get; set; }
    public bool IsRenewable { get; set; }
}

public static class LocalResourceSystem
{
    public static List<ResourceNode> Resources { get; } = new();

    public static void AddResource(string region, string type, int quantity, bool renewable)
    {
        Resources.Add(new ResourceNode
        {
            Region = region,
            ResourceType = type,
            Quantity = quantity,
            IsRenewable = renewable
        });

        Console.WriteLine($"\uD83C\uDF3E Recurso adicionado: {type} em {region} | Qtd: {quantity} | Renovável? {renewable}");
    }

    public static void DepleteResource(string region, string type, int amount)
    {
        var r = Resources.Find(x => x.Region == region && x.ResourceType == type);
        if (r != null)
        {
            r.Quantity -= amount;
            Console.WriteLine($"\u26A0\uFE0F {type} em {region} reduzido em {amount} unidades. Restante: {r.Quantity}");
        }
    }

    public static void PrintResources()
    {
        foreach (var r in Resources)
            Console.WriteLine($"\n\uD83C\uDF0D {r.Region} | {r.ResourceType} | Qtd: {r.Quantity} | Renovável: {r.IsRenewable}");
    }
}
