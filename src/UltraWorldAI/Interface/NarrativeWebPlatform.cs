using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace UltraWorldAI.Interface;

public class NarrativeEntry
{
    public string Name { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
}

public class NarrativeWebPlatform : IDisposable
{
    private readonly HttpListener _listener;
    private readonly ConcurrentBag<NarrativeEntry> _entries = new();
    private bool _running;

    public int Port { get; }

    public NarrativeWebPlatform(int port = 8080)
    {
        Port = port;
        _listener = new HttpListener();
        _listener.Prefixes.Add($"http://localhost:{port}/");
    }

    public void Start()
    {
        if (_running) return;
        _running = true;
        _listener.Start();
        Task.Run(HandleAsync);
    }

    private async Task HandleAsync()
    {
        while (_running)
        {
            var ctx = await _listener.GetContextAsync();
            if (ctx.Request.HttpMethod == "POST" && ctx.Request.Url?.AbsolutePath == "/narratives")
            {
                using var reader = new StreamReader(ctx.Request.InputStream, ctx.Request.ContentEncoding);
                var json = await reader.ReadToEndAsync();
                var entry = JsonSerializer.Deserialize<NarrativeEntry>(json);
                if (entry != null) _entries.Add(entry);
                ctx.Response.StatusCode = 200;
                ctx.Response.Close();
            }
            else if (ctx.Request.HttpMethod == "GET" && ctx.Request.Url?.AbsolutePath == "/narratives")
            {
                var data = JsonSerializer.Serialize(_entries);
                var buffer = Encoding.UTF8.GetBytes(data);
                ctx.Response.OutputStream.Write(buffer, 0, buffer.Length);
                ctx.Response.Close();
            }
            else
            {
                ctx.Response.StatusCode = 404;
                ctx.Response.Close();
            }
        }
    }

    public void Dispose()
    {
        _running = false;
        if (_listener.IsListening)
            _listener.Stop();
        _listener.Close();
    }
}
