namespace SimpleBlog.Application.Services;

using SimpleBlog.Application.Interfaces;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;

public class WebSocketService : IWebSocketService
{
    private readonly ConcurrentDictionary<string, WebSocket> _connections = new();

    public void AddConnection(string id, WebSocket socket) =>
        _connections.TryAdd(id, socket);

    public void RemoveConnection(string id) =>
        _connections.TryRemove(id, out _);

    public async Task BroadcastMessageAsync(string message)
    {
        var buffer = Encoding.UTF8.GetBytes(message);

        foreach (var socket in _connections.Values)
        {
            if (socket.State is not WebSocketState.Open)
                continue;

            await socket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }
}
