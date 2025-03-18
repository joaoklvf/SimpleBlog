using SimpleBlog.Domain.Models.Base;
using SimpleBlog.Domain.Validation;

namespace SimpleBlog.Domain.Models;

public class Post : Entity
{
    public Post(Guid id, Guid authorId, string title, string content)
    {
        Id = id;
        AuthorId = authorId;
        Title = title;
        Content = content;

        ValidateDomain();
    }

    public Guid AuthorId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public virtual User? Author { get; set; }

    internal override void ValidateDomain()
    {
        DomainValidation.When(string.IsNullOrWhiteSpace(Title), "O título não pode estar vazio.");
        DomainValidation.When(Title.Length > 50, "O título não pode ter mais de 50 caracteres.");
        DomainValidation.When(string.IsNullOrWhiteSpace(Content), "O conteúdo não pode estar vazio.");
        DomainValidation.When(Content.Length > 150, "O conteúdo não pode ter mais de 150 caracteres.");
        DomainValidation.When(Guid.Empty == AuthorId, "O autor não pode estar vazio.");
    }
}
