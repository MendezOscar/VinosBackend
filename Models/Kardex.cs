using System;
using System.Collections.Generic;

namespace VinosBackend.Models
{
    public partial class Kardex
    {
        public int Idkardex { get; set; }
        public DateTime? Fecha { get; set; }
        public string Transaccion { get; set; }
        public int? Cantidad { get; set; }
        public int? Item { get; set; }
        public string Motivo { get; set; }
    }
}
