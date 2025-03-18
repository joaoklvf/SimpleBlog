using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.Application.ViewModels
{
    public class PostViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório")]
        [MinLength(2, ErrorMessage = "O tamanho mínimo do título é de 2 caracteres")]
        [MaxLength(50, ErrorMessage = "O tamanho máximo do título é de 50 caracteres")]
        [DisplayName("Título")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "O conteúdo é obrigatório")]
        [MinLength(2, ErrorMessage = "O tamanho mínimo do conteúdo é de 2 caracteres")]
        [MaxLength(50, ErrorMessage = "O tamanho máximo do conteúdo é de 150 caracteres")]
        [DisplayName("Título")]
        public required string Content { get; set; }

        [Required(ErrorMessage = "O ID do usuário é obrigatório")]
        [DisplayName("ID do usuário")]
        public required Guid UserId { get; set; }
    }
}
