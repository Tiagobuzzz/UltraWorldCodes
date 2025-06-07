using System;
using System.Collections.Generic;

namespace UltraWorldAI.Magic;

public class ArcaneMessage
{
    public string Sender { get; set; } = string.Empty;
    public string Receiver { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public bool IsProphetic { get; set; }
}

public static class ArcaneCommunicationSystem
{
    public static List<ArcaneMessage> Messages { get; } = new();

    public static void Send(string sender, string receiver, string content)
    {
        Messages.Add(new ArcaneMessage
        {
            Sender = sender,
            Receiver = receiver,
            Content = content
        });
        Console.WriteLine($"\uD83D\uDCE1 {sender} -> {receiver}: {content}");
    }

    public static void SendPropheticVision(string sender, string receiver, string vision)
    {
        Messages.Add(new ArcaneMessage
        {
            Sender = sender,
            Receiver = receiver,
            Content = vision,
            IsProphetic = true
        });
        Console.WriteLine($"\uD83D\uDD2E {sender} envia vis\u00e3o a {receiver}: {vision}");
    }

    public static List<ArcaneMessage> Retrieve(string receiver)
    {
        return Messages.FindAll(m => m.Receiver == receiver);
    }
}
