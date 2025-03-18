using SimpleBlog.Domain.Models.Base;
using SimpleBlog.Domain.Validation;

namespace SimpleBlog.Domain.Models;

public class Post : Entity
{
    public Post(Guid id, User author, string title, string content)
    {
        ValidateDomain();

        Id = id;
        Author = author;
        Title = title;
        Content = content;
    }

    public virtual User Author { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    internal override void ValidateDomain()
    {
        DomainValidation.When(string.IsNullOrWhiteSpace(Title), "O título não pode estar vazio.");
        DomainValidation.When(Title.Length > 50, "O título não pode ter mais de 50 caracteres.");
        DomainValidation.When(string.IsNullOrWhiteSpace(Content), "O conteúdo não pode estar vazio.");
        DomainValidation.When(Content.Length > 150, "O conteúdo não pode ter mais de 150 caracteres.");
        DomainValidation.When(Author is null, "O autor não pode estar vazio.");
    }
}
