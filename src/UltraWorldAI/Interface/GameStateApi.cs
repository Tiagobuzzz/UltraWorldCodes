using System;
using System.Net;
using System.Text;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using UltraWorldAI.World;

namespace UltraWorldAI.Interface;

/// <summary>
/// Minimal REST API exposing basic game state.
/// </summary>
public class GameStateApi : IDisposable
{
    private readonly HttpListener _listener = new();
    private bool _running;
    public int Port { get; }

    public GameStateApi(int port = 18181)
    {
        Port = port;
        _listener.Prefixes.Add($"http://localhost:{port}/");
    }

    public void Start(CancellationToken cancellationToken = default)
    {
        if (_running) return;
        _running = true;
        _listener.Start();
        _ = HandleAsync(cancellationToken);
    }

    private async Task HandleAsync(CancellationToken cancellationToken)
    {
        while (_running && !cancellationToken.IsCancellationRequested)
        {
            var ctx = await _listener.GetContextAsync();
            if (ctx.Request.HttpMethod == "GET" && ctx.Request.Url?.AbsolutePath == "/map")
            {
                var data = JsonUtility.ToJson(MapFaithEconomyIntegration.Nodes);
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
