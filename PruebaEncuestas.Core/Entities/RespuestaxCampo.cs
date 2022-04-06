using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PruebaEncuestas.Core.Entities
{
    public partial class RespuestaxCampo
    {
        public long IdRespuestaxCampo { get; set; }
        public long? FkRespuestaId { get; set; }
        public long? FkCampoEncuestaId { get; set; }
        public string Respuesta { get; set; }

        public virtual Respuesta FkRespuesta { get; set; }
    }
}
