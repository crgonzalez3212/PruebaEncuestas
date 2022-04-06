using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaEncuestas.Core.DTOs
{
    public class RespuestaDTO
    {
        public string NombrePersona { get; set; }
        public long FkEncuestaId { get; set; }
        public string Respuestas { get; set; }
    }
}
