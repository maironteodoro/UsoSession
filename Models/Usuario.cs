using System.ComponentModel.DataAnnotations;
namespace Tratamento.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        [Required]
        [DataType(DataType.Password)]

        public string? Password { get; set; }
        public string? UserName { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage ="Forneça um email valido com @.")]
        public string? EmailAddress { get; set; }

    }
}
