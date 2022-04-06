using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PruebaEncuestas.Core.Entities
{
    public partial class Encuesta
    {
        public Encuesta()
        {
            CamposEncuesta = new HashSet<CamposEncuesta>();
        }

        public long EncuestaId { get; set; }
        public string EncuestaNombre { get; set; }
        public string EncuestaDescripcion { get; set; }

        public virtual ICollection<CamposEncuesta> CamposEncuesta { get; set; }
    }
}
