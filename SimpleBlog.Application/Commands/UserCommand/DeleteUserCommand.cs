namespace SimpleBlog.Application.Commands.UserCommand;

public class DeleteUserCommand : UserCommandBase
{
    public DeleteUserCommand(Guid id, string userLoggedInId)
    {
        Id = id;
        UserLoggedInId = userLoggedInId;
    }
}
