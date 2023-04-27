using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller.Domain.EntityModels
{
    public class Proveedor
    {
        [Key]
        public int ProveedorId { get; set; }
        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string Direccion { get; set; }
        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string Telefono { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(256)]
        public string CorreoElectronico { get; set; }

       
    }
}
