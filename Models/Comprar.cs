using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App1.Models
{
    public class Comprar
    {
        [Key]
        public int Id_Compra { get; set; }
        

        [ForeignKey("Cliente")]
        [Required(ErrorMessage = "Selecione o Cliente")]
        public string Email_Cliente { get; set; }
        [ForeignKey("Destino")]
        [Required(ErrorMessage = "Selecione o Destino")]
        public int Id_Destino { get; set; }
        public string FormaPagamento { get; set; }
        public DateTime Data_Compra { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Destino Destino { get; set; }
    }
}
