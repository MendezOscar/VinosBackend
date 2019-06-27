using System;
using System.Collections.Generic;

namespace VinosBackend.Models
{
    public partial class Existencias
    {
        public int Idexistencia { get; set; }
        public int? Item { get; set; }
        public int? Cantidad { get; set; }
    }
}
