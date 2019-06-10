using System;
using System.Collections.Generic;

namespace VinosBackend.Models
{
    public partial class Planactividades
    {
        public int Idplanactividades { get; set; }
        public int? Idactividad { get; set; }

        public virtual Actividades IdactividadNavigation { get; set; }
    }
}
