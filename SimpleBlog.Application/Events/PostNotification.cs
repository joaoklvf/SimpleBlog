using MediatR;
using SimpleBlog.Domain.Models;

namespace SimpleBlog.Application.Notifications;

public class PostNotification(Post post) : INotification
{
    public Post Post { get; } = post;
    public DateTime PostDateTime { get; } = DateTime.Now;
}
