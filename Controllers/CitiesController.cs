using BaseApi.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace BaseApi.Controllers
{
    [Route("cities")]
    public class CitiesController : Controller
    {
        private readonly ICitiesService _citiesService;
        public CitiesController(
            ICitiesService citiesService
        )
        {
            _citiesService = citiesService;
        }

        /// <summary>
        /// Busca todas as cidades.
        /// </summary>
        /// <returns></returns>
        [HttpGet("getallcities")]
        public IActionResult GetAllCities()
        {
            var response = _citiesService.GetAllCities();

            return Ok(
                response
            );
        }
    }
}