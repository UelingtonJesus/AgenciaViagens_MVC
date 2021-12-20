using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App1.Models
{
    public class Destino
    {
        [Key]
        public int Id_Destino { get; set; }
        [Required]
        [StringLength(50)]
        
        public string Nome_Destino{ get; set; }
        
       
        
        [Required]
        public string Preco { get; set; }

        public DateTime Hora_Voo { get; set; }

        public virtual List<Destino> Destinos { get; set; }
    }
}
