using System;
using System.Collections.Generic;

namespace VinosBackend.Models
{
    public partial class Personalorden
    {
        public int Idpersonal { get; set; }
        public int? Idempleado { get; set; }

        public virtual Empleado IdempleadoNavigation { get; set; }
    }
}
