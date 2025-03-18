namespace SimpleBlog.Application.Commands.UserCommand;

public class CreateUserCommand : UserCommandBase
{
    public CreateUserCommand(string userName, string password, string name, string email, DateTime birthDate)
    {
        UserName = userName;
        Password = password;
        Name = name;
        Email = email;
        BirthDate = birthDate;
    }
}
