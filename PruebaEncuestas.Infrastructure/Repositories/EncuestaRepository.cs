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
    public class EncuestaRepository : IEncuestaRepository
    {
        private readonly PruebaEncuestaContext _context;
        public EncuestaRepository(PruebaEncuestaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Encuesta>> GetEncuestas()
        {
            var lst = await _context.Encuesta.Include("CamposEncuesta").ToListAsync();


            return lst;
        }

        public long Add(Encuesta req)
        {

            _context.Encuesta.Add(req);

            _context.SaveChanges();

            return  req.EncuestaId;



        }

        public void Update(Encuesta req)
        {

            _context.Encuesta.Update(req);

            _context.SaveChanges();
        }

        public void Delete(Encuesta req)
        {
            if (req.CamposEncuesta.Any())
                _context.CamposEncuesta.RemoveRange(req.CamposEncuesta);

            _context.Encuesta.Remove(req);
            _context.SaveChanges();
        }

        public async Task<Encuesta> GetEncuesta(long id)
        {
            var lst = await _context.Encuesta.Include("CamposEncuesta").Where(x => x.EncuestaId.Equals(id)).ToListAsync();
            return lst.FirstOrDefault();
        }
    }
}
