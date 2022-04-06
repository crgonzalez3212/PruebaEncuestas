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
    public class CampoRepository : ICampoRepository
    {
        private readonly PruebaEncuestaContext _context;
        public CampoRepository(PruebaEncuestaContext context)
        {
            _context = context;
        }


        public async Task<CamposEncuesta> GetCampoEncuesta(long id)
        {
            var campo = _context.CamposEncuesta.Where(x => x.CampoEncuestaId.Equals(id)).FirstOrDefault();

            return campo;
        }
    }
}
