using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaEncuestas.Core.DTOs
{
    public class CamposEncuestaDTO
    {
        public string NombreCampo { get; set; }
        public string TituloCampo { get; set; }
        public bool? EsRequerido { get; set; }
        public string TipoCampo { get; set; }
    }
}
