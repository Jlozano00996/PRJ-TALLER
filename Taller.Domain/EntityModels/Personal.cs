using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller.Domain.EntityModels
{
    public class Personal
    {
        [Key]
        public int PersonalId { get; set; }
        [Required]

        [StringLength(256, MinimumLength = 2)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string Posicion { get; set; }
        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string Telefono { get; set; }
        [Required]
        [MaxLength(256)]
        [EmailAddress]
        public string CorreoElectronico { get; set; }
    }
}
