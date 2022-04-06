using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaEncuestas.Web.Models
{
    public class EncuestaModel
    {
        public long encuestaId { get; set; }
        public string encuestaNombre { get; set; }
        public string encuestaDescripcion { get; set; }

        public List<CamposEncuestasModel> camposEncuesta { get; set; }
    }
}
