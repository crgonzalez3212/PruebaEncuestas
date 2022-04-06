using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaEncuestas.Core.DTOs
{
    public class EncuestaDTO
    {
        public string EncuestaNombre { get; set; }
        public string EncuestaDescripcion { get; set; }

        public List<CamposEncuestaDTO> CamposEncuesta { get; set; }
    }
}
