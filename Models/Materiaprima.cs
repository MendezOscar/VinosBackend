using System;
using System.Collections.Generic;

namespace VinosBackend.Models
{
    public partial class Materiaprima
    {
        public Materiaprima()
        {
            Recetadetalle = new HashSet<Recetadetalle>();
        }

        public int Idmateriaprima { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Recetadetalle> Recetadetalle { get; set; }
    }
}
