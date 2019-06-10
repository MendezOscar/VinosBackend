using System;
using System.Collections.Generic;

namespace VinosBackend.Models
{
    public partial class Proveedorvisita
    {
        public int Idproveedorvisita { get; set; }
        public int? Idproveedor { get; set; }

        public virtual Proveedor IdproveedorNavigation { get; set; }
    }
}
