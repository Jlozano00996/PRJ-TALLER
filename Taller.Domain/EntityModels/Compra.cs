using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller.Domain.EntityModels
{
    public class Compra
    {
        [Key]
        public int CompraId { get; set; }
        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string Nombre { get; set; }
        
        [Required]
        [ForeignKey("Proveedor")]
        public int ProveedorId { get; set; }
        public Proveedor proveedor { get; set; }
        [Required]
        public int CantidadComprada { get; set; }
        [Required]
        public DateTime FechaCompra { get; set; }
    } //= DateTime.Now;


}
