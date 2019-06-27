using System;
using System.Collections.Generic;

namespace VinosBackend.Models
{
    public partial class Materiaprimaoden
    {
        public int Idmateriaprimaorden { get; set; }
        public int? Idmateriaprima { get; set; }
        public int? Idorden { get; set; }

        public virtual Ordendeproduccion IdordenNavigation { get; set; }
    }
}
