using System;
using System.Collections.Generic;

namespace VinosBackend.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            Personalorden = new HashSet<Personalorden>();
        }

        public int Idempleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? Edad { get; set; }
        public DateTime? Fechanacimiento { get; set; }
        public string Cargo { get; set; }

        public virtual ICollection<Personalorden> Personalorden { get; set; }
    }
}
