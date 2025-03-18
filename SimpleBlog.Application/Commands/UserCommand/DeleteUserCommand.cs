namespace SimpleBlog.Application.Commands.UserCommand;

public class DeleteUserCommand : UserCommandBase
{
    public DeleteUserCommand(Guid id)
    {
        Id = id;
    }
}
