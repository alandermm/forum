using System;
using System.ComponentModel.DataAnnotations;

namespace Forum.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Nome do usuário")]
        [Required(ErrorMessage="Este campo não pode ficar vazio")]
        [MinLength(2, ErrorMessage="Você deve inserir um nome com mais de 2 caracteres.")]
        [MaxLength(10, ErrorMessage="Você deve inserir um nome com até 10 caracteres.")]
        public string Nome { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(20)]
        public string Login { get; set; }

        [MinLength(8)]
        [MaxLength(12)]
        [RegularExpression(@"^[a-zA-Z-'\s]{1,40}$")]
        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}