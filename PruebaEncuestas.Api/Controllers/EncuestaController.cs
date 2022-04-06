using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PruebaEncuestas.Core.DTOs;
using PruebaEncuestas.Core.Entities;
using PruebaEncuestas.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaEncuestas.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EncuestaController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IEncuestaRepository _EncuestaRepository;
        private readonly IMapper _mapper;

        public EncuestaController(IEncuestaRepository encuRepo,IMapper mapper, IConfiguration config)
        {
            _EncuestaRepository = encuRepo;
            _mapper = mapper;
            _configuration = config;
        }

        [HttpGet]
        [Route("GetEncuestas")]
        public IActionResult GetEncuestas()
        {
            var lst = _EncuestaRepository.GetEncuestas().Result;
            var lstDto = _mapper.Map<IEnumerable<EncuestaDTO>>(lst);
            return Ok(lst);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetEncuesta/{id}")]
        public IActionResult GetEncuesta(long id)
        {
            var lst = _EncuestaRepository.GetEncuesta(id).Result;

            if (lst == null)
                return NotFound("Encuesta no encontrada");
            return Ok(lst);
        }

        [HttpPost]
        [Route("AddEncuesta")]
        public IActionResult AddEncuestas(EncuestaDTO request)
        {
            var encuestaMap = _mapper.Map<Encuesta>(request);
            long id=_EncuestaRepository.Add(encuestaMap);
            string url = string.Format(_configuration["urlEncuesta"], id);
            return Ok(url);
        }

        [HttpPost]
        [Route("UpdateEncuesta")]
        public IActionResult UpdateEncuestas(Encuesta request)
        {
            request.CamposEncuesta.ToList().ForEach(x => x.FkEncuestaId = request.EncuestaId);
            _EncuestaRepository.Update(request);
            return Ok();
        }

        [HttpPost]
        [Route("DeleteEncuesta")]
        public IActionResult DeleteEncuesta(EncuestaIdDTO request)
        {
            var lst = _EncuestaRepository.GetEncuesta(request.EncuestaId).Result;

            if (lst == null)
                return NotFound("Encuesta no encontrada");

            _EncuestaRepository.Delete(lst);
            return Ok();
        }


    }
}
