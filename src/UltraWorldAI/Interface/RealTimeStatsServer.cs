using System;
using System.Net;
using System.Text;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using UltraWorldAI.World;

namespace UltraWorldAI.Interface;

public class RealTimeStatsServer : IDisposable
{
    private readonly HttpListener _listener = new();
    private bool _running;
    public int Port { get; }

    public RealTimeStatsServer(int port = 19090)
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
            HttpListenerContext ctx;
            try
            {
                ctx = await _listener.GetContextAsync();
            }
            catch (HttpListenerException ex)
            {
                Logger.LogError("RealTimeStatsServer failed", ex);
                continue;
            }
            if (ctx.Request.HttpMethod == "GET" && ctx.Request.Url?.AbsolutePath == "/stats")
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
