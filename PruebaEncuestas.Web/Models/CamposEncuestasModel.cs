using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaEncuestas.Web.Models
{
    public class CamposEncuestasModel
    {
        public long campoEncuestaId { get; set; }
        public string nombreCampo { get; set; }
        public string tituloCampo { get; set; }
        public bool? esRequerido { get; set; }
        public string tipoCampo { get; set; }
    }
}
