using BaseApi.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace BaseApi.Controllers
{
    [Route("gravity")]
    public class GravityController : Controller
    {
        private readonly IGravityService _gravityService;
        public GravityController(
            IGravityService gravityService
        )
        {
            _gravityService = gravityService;
        }

        /// <summary>
        /// Busca todas os niveis de gravidades.
        /// </summary>
        /// <returns></returns>
        [HttpGet("getallgravity")]
        public IActionResult GetAllGravity()
        {
            var response = _gravityService.GetAllGravity();

            return Ok(
                response
            );
        }
    }
}