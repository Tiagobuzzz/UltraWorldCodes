using System;
using System.Net;
using System.Text;
using System.Text.Json;
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
            if (ctx.Request.HttpMethod == "GET" && ctx.Request.Url?.AbsolutePath == "/stats")
            {
                var data = JsonSerializer.Serialize(MapFaithEconomyIntegration.Nodes);
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
