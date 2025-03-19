using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.Application.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "O nome de usuário é obrigatório")]
    [MinLength(2, ErrorMessage = "O tamanho mínimo do nome de usuário é de 2 caracteres")]
    [MaxLength(100, ErrorMessage = "O tamanho máximo do nome de usuário é de 100 caracteres")]
    [DisplayName("Nome de usuário")]
    public required string UserName { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "A senha é obrigatório")]
    [MinLength(2, ErrorMessage = "O tamanho mínimo da senha é de 10 caracteres")]
    [MaxLength(100, ErrorMessage = "O tamanho máximo da senha é de 100 caracteres")]
    [DisplayName("Senha")]
    public required string Password { get; set; }
}
