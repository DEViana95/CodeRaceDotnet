using BaseApi.Controllers.DTO;
using BaseApi.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace BaseApi.Controllers
{
    [Route("incidentTypes")]
    public class IncidentTypesController : ControllerBase
    {
        private readonly IIncidentTypesService _incidentTypesService;
        public IncidentTypesController(
            IIncidentTypesService incidentTypesService
        )
        {
            _incidentTypesService = incidentTypesService;
        }

        /// <summary>
        /// Busca os desastres naturais páginados.
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public IActionResult GetAll(
            [FromQuery] int skip,
            [FromQuery] int take
        )
        {
            var response = _incidentTypesService.GetAll(
                skip: skip,
                take: take
            );

            return Ok(
                response
            );
        }

        /// <summary>
        /// Busca um desastre natural por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(
            [FromQuery] long id
        )
        {
            var response = _incidentTypesService
                .Get(id);

            return Ok(
                response
            );
        }

        /// <summary>
        /// Cria um desastre natural.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(
            [FromBody] CreateIncidentTypeDTO incidentType
        )
        {
            var response = _incidentTypesService.Create(incidentType);

            return Ok(
                response
            );
        }

        /// <summary>
        /// Atualiza o desastre natural.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(
            [FromBody] UpdateIncidentTypeDTO incidentType
        )
        {
            var response = _incidentTypesService.Update(incidentType);

            return Ok(
                response
            );
        }

        /// <summary>
        /// Deleta um desastre natural.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(
            [FromQuery] long id
        )
        {
            var response = _incidentTypesService.Delete(id);

            return Ok(
                response
            );
        }
    }
}