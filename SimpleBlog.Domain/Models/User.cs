using SimpleBlog.Domain.Models.Base;
using SimpleBlog.Domain.Validation;

namespace SimpleBlog.Domain.Models;

public class User : Entity
{
    public User(Guid id, string userName, string password, string name, string email, DateTime birthDate)
    {
        Id = id;
        UserName = userName;
        Password = password;
        Name = name;
        Email = email;
        BirthDate = birthDate;

        ValidateDomain();
    }

    public string UserName { get; private set; }
    public string Password { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set; }
    public virtual IEnumerable<Post>? Posts { get; private set; }

    internal override void ValidateDomain()
    {
        DomainValidation.When(string.IsNullOrWhiteSpace(UserName), "O nome de usuário não pode estar vazio.");
        DomainValidation.When(UserName.Length > 100, "O nome de usuário não pode ter mais de 100 caracteres.");
        DomainValidation.When(string.IsNullOrWhiteSpace(Password), "A senha não pode estar vazia.");
        DomainValidation.When(Password.Length > 100, "A senha não pode ter mais de 100 caracteres.");
        DomainValidation.When(string.IsNullOrWhiteSpace(Name), "O nome não pode estar vazio.");
        DomainValidation.When(Password.Length > 100, "O nome não pode ter mais de 100 caracteres.");
        DomainValidation.When(string.IsNullOrWhiteSpace(Email), "O e-mail não pode estar vazio.");
        DomainValidation.When(Password.Length > 100, "O e-mail não pode ter mais de 100 caracteres.");
        DomainValidation.When(BirthDate == DateTime.MinValue, "A data de nascimento não pode estar vazia.");
    }
}
