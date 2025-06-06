using System;
using System.Collections.Generic;

namespace UltraWorldAI.Language;

public class CipherMessage
{
    public string Sender { get; set; } = string.Empty;
    public string Receiver { get; set; } = string.Empty;
    public string EncodedMessage { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty;
    public string DecodedMeaning { get; set; } = string.Empty;
}

public static class CryptolinguisticCommunicationSystem
{
    public static List<CipherMessage> Messages { get; } = new();

    public static void SendEncoded(string sender, string receiver, string message, string key)
    {
        var encoded = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{message}:{key}"));
        Messages.Add(new CipherMessage
        {
            Sender = sender,
            Receiver = receiver,
            EncodedMessage = encoded,
            Key = key,
            DecodedMeaning = message
        });

        Console.WriteLine($"\uD83D\uDCE1 Mensagem cifrada enviada de {sender} para {receiver}.");
    }

    public static void AttemptDecode(string receiver, string keyAttempt)
    {
        foreach (var m in Messages)
        {
            if (m.Receiver == receiver)
            {
                if (m.Key == keyAttempt)
                {
                    Console.WriteLine($"\uD83D\uDD13 {receiver} decifrou: {m.DecodedMeaning}");
                }
                else
                {
                    Console.WriteLine($"\u274C {receiver} falhou em decifrar a mensagem.");
                }
            }
        }
    }

    public static void PrintAllMessages()
    {
        foreach (var m in Messages)
        {
            Console.WriteLine($"\n\uD83D\uDCE8 {m.Sender} → {m.Receiver} | Mensagem Cifrada: {m.EncodedMessage}");
        }
    }
}
