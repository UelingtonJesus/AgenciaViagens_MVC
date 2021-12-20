using System.ComponentModel.DataAnnotations;

namespace App1.Models
{
    public class Contato
    {
        [Key]

        public int Id_Contato { get; set; }
        [Required]
        public string Email { get; set; }
        public string Mensagem { get; set; }
    }
}
