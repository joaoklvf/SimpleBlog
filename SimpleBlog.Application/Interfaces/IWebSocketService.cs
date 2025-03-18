using System.Net.WebSockets;

namespace SimpleBlog.Application.Interfaces;

public interface IWebSocketService
{
    void AddConnection(string id, WebSocket socket);
    void RemoveConnection(string id);
    Task BroadcastMessageAsync(string message);
}
