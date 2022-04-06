
using PruebaEncuestas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaEncuestas.Core.Interfaces
{
    public interface IEncuestaRepository
    {
        long Add(Encuesta req);

        void Update(Encuesta req);

        void Delete(Encuesta req);

        Task<IEnumerable<Encuesta>> GetEncuestas();

        Task<Encuesta> GetEncuesta(long id);
    }
}
