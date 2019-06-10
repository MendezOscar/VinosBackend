using System;
using System.Collections.Generic;

namespace VinosBackend.Models
{
    public partial class Personalvisita
    {
        public int Idpersonalvisita { get; set; }
        public int? Idempleado { get; set; }

        public virtual Empleado IdempleadoNavigation { get; set; }
    }
}
