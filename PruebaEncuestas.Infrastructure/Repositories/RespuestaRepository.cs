using Microsoft.EntityFrameworkCore;
using PruebaEncuestas.Core.Entities;
using PruebaEncuestas.Core.Interfaces;
using PruebaEncuestas.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaEncuestas.Infrastructure.Repositories
{
    public class RespuestaRepository : IRespuestaRepository
    {
        private readonly PruebaEncuestaContext _context;


        public RespuestaRepository(PruebaEncuestaContext context)
        {
            _context = context;
        }

        public void Add(Respuesta respuesta)
        {
            _context.Respuesta.Add(respuesta);
            _context.SaveChanges();
        }

        public  async Task<IEnumerable<Respuesta>> GetRespuestas(long idEncuesta)
        {
            var lst = await _context.Respuesta.Include("RespuestaxCampo").Where(x => x.FkEncuestaId.Equals(idEncuesta)).ToListAsync();
            return lst;
        }
    }
}
