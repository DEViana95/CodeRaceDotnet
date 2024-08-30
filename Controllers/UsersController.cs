using BaseApi.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace BaseApi.Controllers
{
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _userService;
        public UsersController(
            IUsersService userService
        )
        {
            _userService = userService;
        }

        [HttpGet("teste")]
        public IActionResult Teste()
        {
            var response = _userService.Get();

            return Ok(
                response
            );
        }
    }
}