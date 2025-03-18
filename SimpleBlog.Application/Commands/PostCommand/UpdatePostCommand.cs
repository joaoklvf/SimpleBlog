namespace SimpleBlog.Application.Commands.PostCommand;

public class UpdatePostCommand : PostCommandBase
{
    public UpdatePostCommand(Guid id, string title, string content)
    {
        Id = id;
        Title = title;
        Content = content;
    }
}
