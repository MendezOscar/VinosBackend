using System;
using System.Collections.Generic;

namespace VinosBackend.Models
{
    public partial class Materiaprima
    {
        public int Idmateriaprima { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? Idproveedor { get; set; }

        public virtual Proveedor IdproveedorNavigation { get; set; }
    }
}
