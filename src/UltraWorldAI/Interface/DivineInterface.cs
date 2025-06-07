using System;
using UltraWorldAI.DivineWorld;

namespace UltraWorldAI.Interface;

public class DivineInterface
{
    public string SelectedActionType { get; set; } = string.Empty;
    public string Target { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public void ShowMenu()
    {
        Console.WriteLine("\uD83C\uDF9C\uFE0F MODO DEUS \u2013 ESCOLHA SUA A\u00C7\u00C3O:");
        Console.WriteLine("1. Milagre");
        Console.WriteLine("2. Cat\u00e1strofe");
        Console.WriteLine("3. Revela\u00e7\u00e3o");
        Console.WriteLine("4. Criar entidade ou plano");
        Console.WriteLine("5. Moldar territ\u00f3rio");
    }

    public void ConfirmAction()
    {
        DivineWillSystem.Intervene(Target, SelectedActionType, Description);
        Console.WriteLine($"\u2705 A\u00e7\u00e3o divina enviada: {SelectedActionType} \u2192 {Target}");
    }
}
