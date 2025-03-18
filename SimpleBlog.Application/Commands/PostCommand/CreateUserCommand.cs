namespace SimpleBlog.Application.Commands.PostCommand;

public class CreatePostCommand : PostCommandBase
{
    public CreatePostCommand(string title, string content)
    {
        Title = title;
        Content = content;
    }
}
