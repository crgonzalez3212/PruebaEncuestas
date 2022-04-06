
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PruebaEncuestas.Core.Entities
{
    public partial class CamposEncuesta
    {
        public long CampoEncuestaId { get; set; }
        public string NombreCampo { get; set; }
        public string TituloCampo { get; set; }
        public bool? EsRequerido { get; set; }
        public string TipoCampo { get; set; }
        public long FkEncuestaId { get; set; }

        public virtual Encuesta FkEncuesta { get; set; }
    }
}
