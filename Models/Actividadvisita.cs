using System;
using System.Collections.Generic;

namespace VinosBackend.Models
{
    public partial class Actividadvisita
    {
        public int Actividadvisita1 { get; set; }
        public int? Idactividad { get; set; }
        public int? Idvisita { get; set; }

        public virtual Visita IdvisitaNavigation { get; set; }
    }
}
