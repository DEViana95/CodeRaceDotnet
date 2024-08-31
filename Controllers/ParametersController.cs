using BaseApi.Controllers.DTO;
using BaseApi.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace BaseApi.Controllers
{
    [Route("parameters")]
    public class ParametersController : ControllerBase
    {
        private readonly IParametersService _parametersService;
        public ParametersController(
            IParametersService parametersService
        )
        {
            _parametersService = parametersService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = _parametersService
                .Get();

            return Ok(
                response
            );
        }

        [HttpPut]
        public IActionResult Update(
            [FromBody] UpdateParametersDTO parameters
        )
        {
            var response = _parametersService.Update(parameters);

            return Ok(
                response
            );
        }
    }
}