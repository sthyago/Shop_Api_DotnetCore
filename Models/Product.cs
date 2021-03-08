using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório.")]
        [MaxLength(60, ErrorMessage = "O Título precisa ter entre 3 e 60 caracteres.")]
        [MinLength(3, ErrorMessage = "O Título precisa ter entre 3 e 60 caracteres.")]
        public string Name { get; set; }

        [Range(0.1, 999999, ErrorMessage = "O preço dece estar entre .1 e 999999")]
        [Required(ErrorMessage = "O preço é obrigatório")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}