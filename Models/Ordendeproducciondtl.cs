using System;
using System.Collections.Generic;

namespace VinosBackend.Models
{
    public partial class Ordendeproducciondtl
    {
        public int Idordendetalle { get; set; }
        public int? Idorden { get; set; }
        public int? Idreceta { get; set; }
        public int? Idpersonal { get; set; }

        public virtual Ordendeproduccionhdr IdordenNavigation { get; set; }
        public virtual Personalorden IdpersonalNavigation { get; set; }
    }
}
