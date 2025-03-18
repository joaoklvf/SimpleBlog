using MediatR;
using SimpleBlog.Domain.Models;

namespace SimpleBlog.Application.Commands.UserCommand;

public abstract class UserCommandBase : IRequest<User>
{
    public Guid Id { get; protected set; }
    public string UserName { get; protected set; } = string.Empty;
    public string Password { get; protected set; } = string.Empty;
    public string Name { get; protected set; } = string.Empty;
    public string Email { get; protected set; } = string.Empty;
    public DateTime BirthDate { get; protected set; }
}
