namespace SimpleBlog.Application.Commands.PostCommand;

public class DeletePostCommand : PostCommandBase
{
    public DeletePostCommand(Guid id, string userLoggedInId)
    {
        Id = id;
        UserLoggedInId = userLoggedInId;
    }
}
