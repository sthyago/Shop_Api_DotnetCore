using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MaxLength(60, ErrorMessage = "O Título precisa ter entre 3 e 60 caracteres.")]
        [MinLength(3, ErrorMessage = "O Título precisa ter entre 3 e 60 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo função é obrigatório.")]
        public UserRoleEnum Role { get; set; }
    }
}