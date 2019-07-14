using System;
using System.Collections.Generic;

namespace VinosBackend.Models
{
    public partial class Ordendeproduccion
    {
        public Ordendeproduccion()
        {
            Materiaprimaoden = new HashSet<Materiaprimaoden>();
        }

        public int Idorden { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Fecha { get; set; }
        public int? Cantidadobtenida { get; set; }
        public string Item { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Materiaprimaoden> Materiaprimaoden { get; set; }
    }
}
