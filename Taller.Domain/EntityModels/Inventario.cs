using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller.Domain.EntityModels
{
    public class Inventario
    {
        [Key]
        public int InventarioId { get; set; }
        [Required]
        [ForeignKey("Compra")]
        public int CompraId { get; set; }
        public Compra compra { get; set; }
       
        [Required]
        public int CantidadDisponible { get; set; }
        [Required]
        [StringLength(256, MinimumLength =2)]
        public string UbicacionAlmacen { get; set; }
        [Required]
        public DateTime FechaLlegada  { get; set; } //= DateTime.Now; 
        [Required]
        public DateTime FechaSalida { get; set; } //= DateTime.Now;
    }
}
