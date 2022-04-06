using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaEncuestas.Core.DTOs
{
    public class RespuestaConsultaDTO
    {
        public string NombrePersona { get; set; }

        public string Fecha { get; set; }

        public List<RespuestasXCampoDTO> lstRespuestas { get; set; }
    }
}
