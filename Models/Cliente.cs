using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App1.Models
{
    public class Cliente
    {
        
        public int Id_Cliente { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome_Cliente{ get; set; }
        [Required]
        [StringLength(50)]
        [Key]
        public string Email_Cliente{ get; set; }
        [Required]
        [StringLength(11)]
        public string CPF { get; set; }



        public virtual List<Cliente> Clientes { get; set; }

    }
}
