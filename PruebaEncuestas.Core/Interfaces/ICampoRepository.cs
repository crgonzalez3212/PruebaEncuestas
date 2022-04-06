using PruebaEncuestas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaEncuestas.Core.Interfaces
{
    public interface ICampoRepository
    {
        Task<CamposEncuesta> GetCampoEncuesta(long id);
    }
}
