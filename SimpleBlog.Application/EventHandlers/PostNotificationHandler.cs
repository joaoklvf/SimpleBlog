using MediatR;
using SimpleBlog.Application.Interfaces;
using SimpleBlog.Application.Notifications;
using System.Net.Http;

namespace SimpleBlog.Application.EventHandlers;

public class PostNotificationHandler(IWebSocketService webSocketService) : INotificationHandler<PostNotification>
{
    private readonly IWebSocketService _webSocketService = webSocketService;

    private static string GetMessage(PostNotification notification) =>
        $"Novo post de {notification.Post.Author!.Name}: {notification.Post.Title}. Postado {notification.PostDateTime:dd/MM/yyyy - HH:mm:ss}";

    public async Task Handle(PostNotification notification, CancellationToken cancellationToken)
    {
        var message = GetMessage(notification);
        await _webSocketService.BroadcastMessageAsync(message);
    }
}
