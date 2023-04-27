using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller.Domain.EntityModels
{
    public class Precio
    {
        [Key]
        public int PrecioId { get; set; }
        [Required]
        [ForeignKey("Compra")]
        public int CompraId { get; set; }
        public Compra compra { get; set; }
        [Required]
        public int CostoCompra { get; set; }
        [Required]
        public int PrecioVenta { get; set; }
        [Required]
        public int MargenGanancias { get; set; }
        [Required]
        public DateTime FechaActualizacion { get; set; }
     //= DateTime.Now;


}
}
