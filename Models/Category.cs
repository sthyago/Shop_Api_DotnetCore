using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório.")]
        [MaxLength(60, ErrorMessage = "O Título precisa ter entre 3 e 60 caracteres.")]
        [MinLength(3, ErrorMessage = "O Título precisa ter entre 3 e 60 caracteres.")]
        public string Title { get; set; }
    }
}