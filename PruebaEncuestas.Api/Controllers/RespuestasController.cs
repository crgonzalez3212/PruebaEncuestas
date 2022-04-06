using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaEncuestas.Core.DTOs;
using PruebaEncuestas.Core.Entities;
using PruebaEncuestas.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaEncuestas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespuestasController : ControllerBase
    {
        private readonly IRespuestaRepository _respuestasRepository;
        private readonly ICampoRepository _camposRepository;
        public RespuestasController(IRespuestaRepository repo, ICampoRepository repoCampo)
        {
            _respuestasRepository = repo;
            _camposRepository = repoCampo;
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(RespuestaDTO request)
        {
            List<RespuestaxCampo> lstResp = new List<RespuestaxCampo>();

            var array1 = request.Respuestas.Split('|');

            foreach (var item in array1)
            {
                if (item != string.Empty)
                {
                    RespuestaxCampo itemNew = new RespuestaxCampo();

                    long idCampo = Convert.ToInt64(item.Split('_')[0]);

                    string respuesta = item.Split('_')[1];

                    itemNew.FkCampoEncuestaId = idCampo;
                    itemNew.Respuesta = respuesta;

                    lstResp.Add(itemNew);
                }
            }

            Respuesta newRespuesta = new Respuesta();
            newRespuesta.FkEncuestaId = request.FkEncuestaId;
            newRespuesta.NombrePersona = request.NombrePersona;
            newRespuesta.FechaRespuesta = DateTime.Now;
            newRespuesta.RespuestaxCampo = lstResp;

            _respuestasRepository.Add(newRespuesta);


            return Ok(newRespuesta);
        }

        [Authorize]
        [HttpPost]
        [Route("GetResultadosEncuesta")]
        public IActionResult GetResultadosEncuesta(EncuestaIdDTO request)
        {

            var lstRespu = _respuestasRepository.GetRespuestas(request.EncuestaId).Result;

            List<RespuestaConsultaDTO> lstRetorno = new List<RespuestaConsultaDTO>();


            foreach (var item in lstRespu)
            {
                RespuestaConsultaDTO respNew = new RespuestaConsultaDTO();
                respNew.NombrePersona = item.NombrePersona;
                respNew.Fecha = item.FechaRespuesta.ToString();
                List<RespuestasXCampoDTO> lstCampos = new List<RespuestasXCampoDTO>();
                foreach (var itemCampo in item.RespuestaxCampo)
                {
                    RespuestasXCampoDTO itemCampoNew = new RespuestasXCampoDTO();

                    itemCampoNew.Pregunta = _camposRepository.GetCampoEncuesta(itemCampo.FkCampoEncuestaId.Value).Result.TituloCampo;
                    itemCampoNew.Respuesta = itemCampo.Respuesta;
                    lstCampos.Add(itemCampoNew);
                }
                respNew.lstRespuestas = lstCampos;


                lstRetorno.Add(respNew);
            }

            return Ok(lstRetorno);
        }
    }
}
