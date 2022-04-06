using PruebaEncuestas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaEncuestas.Core.Interfaces
{
    public interface IRespuestaRepository
    {
        public void Add(Respuesta respuesta);

        public Task<IEnumerable<Respuesta>> GetRespuestas(long idEncuesta);
    }
}
