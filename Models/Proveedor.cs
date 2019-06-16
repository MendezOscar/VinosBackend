using System;
using System.Collections.Generic;

namespace VinosBackend.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Proveedorvisita = new HashSet<Proveedorvisita>();
        }

        public int Idproveedor { get; set; }
        public string Nombre { get; set; }
        public string Contacto { get; set; }

        public virtual ICollection<Proveedorvisita> Proveedorvisita { get; set; }
    }
}
