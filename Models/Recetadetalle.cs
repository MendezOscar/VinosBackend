using System;
using System.Collections.Generic;

namespace VinosBackend.Models
{
    public partial class Recetadetalle
    {
        public int Idrecetadetalle { get; set; }
        public int? Periodicidad { get; set; }
        public int? Idmateriaprima { get; set; }
        public int? Cantidad { get; set; }
        public string Medida { get; set; }
        public int? Idreceta { get; set; }

        public virtual Materiaprima IdmateriaprimaNavigation { get; set; }
        public virtual Recetahdr IdrecetaNavigation { get; set; }
    }
}
