using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.EntityModels;

namespace Taller.Domain.ViewModels
{
    public class Compra
    {
        public EntityModels.Compra compra { get; set; }
        public IEnumerable<EntityModels.Proveedor> proveedores { get; set; }
    }

    public class Repuesto
    {
        public EntityModels.Repuesto repuesto { get; set; }
        public IEnumerable<EntityModels.Compra> compras { get; set; }
    }

    public class Inventario
    {
        public EntityModels.Inventario inventario { get; set; }
        public IEnumerable<EntityModels.Compra> compras { get; set; }
    }

    public class Precio
    {
        public EntityModels.Precio precio { get; set; }
        public IEnumerable<EntityModels.Compra> compras { get; set; }
    }
}
