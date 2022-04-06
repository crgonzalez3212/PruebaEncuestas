using AutoMapper;
using PruebaEncuestas.Core.DTOs;
using PruebaEncuestas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaEncuestas.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<CamposEncuesta, CamposEncuestaDTO>();
            CreateMap<CamposEncuestaDTO, CamposEncuesta>();
            CreateMap<Encuesta, EncuestaDTO>();
            CreateMap<EncuestaDTO, Encuesta>().ForMember(d => d.CamposEncuesta, o => o.MapFrom(sess => sess.CamposEncuesta));
        }
    }
}
