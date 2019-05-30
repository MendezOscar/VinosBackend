using System;
using System.Collections.Generic;

namespace VinosBackend.Models
{
    public partial class Recetadtl
    {
        public int Idrecetadetalle { get; set; }
        public int? Periodicidad { get; set; }
        public int? Idmateriaprima { get; set; }
        public int? Idreceta { get; set; }

        public virtual Materiaprima IdmateriaprimaNavigation { get; set; }
        public virtual Recetahdr IdrecetaNavigation { get; set; }
    }
}
