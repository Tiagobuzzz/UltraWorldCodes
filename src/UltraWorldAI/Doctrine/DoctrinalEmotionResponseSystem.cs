using System;
using System.Collections.Generic;

namespace UltraWorldAI.Doctrine;

public class DoctrinalEmotion
{
    public string IAName { get; set; } = string.Empty;
    public string Doctrine { get; set; } = string.Empty;
    public double FaithAttachment { get; set; }
    public double Anger { get; set; }
    public double Sadness { get; set; }
    public double Fanaticism { get; set; }
}

public static class DoctrinalEmotionResponseSystem
{
    public static List<DoctrinalEmotion> Responses { get; } = new();

    public static void RegisterIA(string name, string doctrine, double attachment)
    {
        Responses.Add(new DoctrinalEmotion
        {
            IAName = name,
            Doctrine = doctrine,
            FaithAttachment = attachment,
            Anger = 0,
            Sadness = 0,
            Fanaticism = 0
        });
    }

    public static void ReactToTrauma(string name, string betrayalType)
    {
        var r = Responses.Find(e => e.IAName == name);
        if (r == null) return;

        switch (betrayalType)
        {
            case "Profana\u00e7\u00e3o":
                r.Anger += r.FaithAttachment * 0.5;
                r.Fanaticism += r.FaithAttachment * 0.3;
                break;
            case "Heresia Interna":
                r.Sadness += r.FaithAttachment * 0.4;
                r.Fanaticism += r.FaithAttachment * 0.2;
                break;
            case "Censura da Doutrina":
                r.Anger += r.FaithAttachment * 0.3;
                r.Sadness += r.FaithAttachment * 0.3;
                break;
        }

        Console.WriteLine($"\ud83d\udca5 {name} reagiu com emo\u00e7\u00f5es \u00e0 {betrayalType} da doutrina {r.Doctrine}:");
        Console.WriteLine($"\ud83d\ude21 Raiva: {r.Anger:F2} | \ud83d\ude22 Tristeza: {r.Sadness:F2} | \ud83d\udd25 Fanatismo: {r.Fanaticism:F2}");
    }
}
