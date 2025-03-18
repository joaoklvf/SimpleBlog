namespace SimpleBlog.Application.Commands.UserCommand;

public class UpdateUserCommand : UserCommandBase
{
    public UpdateUserCommand(Guid id, string userName, string password, string name, string email, DateTime birthDate)
    {
        Id = id;
        UserName = userName;
        Password = password;
        Name = name;
        Email = email;
        BirthDate = birthDate;
    }
}
