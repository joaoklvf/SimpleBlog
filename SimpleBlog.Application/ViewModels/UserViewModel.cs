using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SimpleBlog.Application.ViewModels
{
    public class UserViewModel
    {
        [Key]
        public Guid Id { get; set; }

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

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(2, ErrorMessage = "O tamanho mínimo do nome é de 2 caracteres")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo do nome é de 100 caracteres")]
        [DisplayName("Nome")]
        public required string Name { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [MinLength(2, ErrorMessage = "O tamanho mínimo do e-mail é de 2 caracteres")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo do e-mail é de 100 caracteres")]
        [DisplayName("Título")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "O título é obrigatório")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "dd/MM/yyyy")]
        [DisplayName("Título")]
        public required DateTime BirthDate { get; set; }
    }
}
