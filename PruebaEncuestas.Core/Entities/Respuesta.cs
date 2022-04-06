using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PruebaEncuestas.Core.Entities
{
    public partial class Respuesta
    {
        public Respuesta()
        {
            RespuestaxCampo = new HashSet<RespuestaxCampo>();
        }

        public long RespuestaId { get; set; }
        public string NombrePersona { get; set; }
        public DateTime FechaRespuesta { get; set; }
        public long FkEncuestaId { get; set; }

        public virtual ICollection<RespuestaxCampo> RespuestaxCampo { get; set; }
    }
}
