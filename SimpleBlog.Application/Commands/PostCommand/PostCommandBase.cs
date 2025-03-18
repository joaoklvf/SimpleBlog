using MediatR;
using SimpleBlog.Domain.Models;

namespace SimpleBlog.Application.Commands.PostCommand;

public abstract class PostCommandBase : IRequest<Post>
{
    public Guid Id { get; protected set; }
    public Guid AuthorId { get; protected set; }
    public string Title { get; protected set; } = string.Empty;
    public string Content { get; protected set; } = string.Empty;
}
