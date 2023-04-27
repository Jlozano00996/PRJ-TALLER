using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller.Domain.EntityModels
{
    public class Repuesto
    {
        [Key]
        public int RepuestoId { get; set; }
      
        [Required]
        [StringLength(256, MinimumLength = 2)]
        [DisplayName("Numero de Pieza")]
        public string NumeroPieza { get; set; }
        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string Descripcion { get; set; }
        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string Fabricante { get; set; }
        [Required]
        [StringLength(256, MinimumLength = 2)]
        [DisplayName("Model de Vehiculo")]
        public string ModeloVehiculo { get; set; }
        [Required]
        [DisplayName("Año")]
        public int Anio { get; set; }
        [Required]
        [ForeignKey("Compra")]
        public int CompraId { get; set; }
        public Compra compra { get; set; }
    }
}
