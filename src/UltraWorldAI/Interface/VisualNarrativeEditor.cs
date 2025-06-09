using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UltraWorldAI.Interface;

public class NarrativeScene
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
}

public class VisualNarrativeEditor
{
    private readonly List<NarrativeScene> _scenes = new();
    private int _counter;

    public IReadOnlyList<NarrativeScene> Scenes => _scenes;

    public NarrativeScene AddScene(string description)
    {
        var scene = new NarrativeScene { Id = ++_counter, Description = description };
        _scenes.Add(scene);
        return scene;
    }

    public bool RemoveScene(int id) => _scenes.RemoveAll(s => s.Id == id) > 0;

    public void MoveScene(int id, int newIndex)
    {
        var index = _scenes.FindIndex(s => s.Id == id);
        if (index < 0 || newIndex < 0 || newIndex >= _scenes.Count) return;
        var scene = _scenes[index];
        _scenes.RemoveAt(index);
        _scenes.Insert(newIndex, scene);
    }

    public string ExportJson() => JsonUtility.ToJson(_scenes);
}
