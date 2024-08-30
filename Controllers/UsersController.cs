using BaseApi.Controllers.DTO;
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

        /// <summary>
        /// Busca os usuários páginados.
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public IActionResult GetAll(
            [FromQuery] int skip,
            [FromQuery] int take
        )
        {
            var response = _userService.GetAll(
                skip: skip,
                take: take
            );

            return Ok(
                response
            );
        }

        /// <summary>
        /// Busca um usuário por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(
            [FromQuery] long id
        )
        {
            var response = _userService
                .Get(id);

            return Ok(
                response
            );
        }

        /// <summary>
        /// Cria um usuário.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(
            [FromBody] CreateUserDTO user
        )
        {
            var response = _userService.Create(user);

            return Ok(
                response
            );
        }

        /// <summary>
        /// Atualiza o usuário.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(
            [FromBody] UpdateUserDTO user
        )
        {
            var response = _userService.Update(user);

            return Ok(
                response
            );
        }

        /// <summary>
        /// Deleta um usuário.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(
            [FromQuery] long id
        )
        {
            var response = _userService.Delete(id);

            return Ok(
                response
            );
        }

        /// <summary>
        /// Acesso ao usuário.
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet("login")]
        public IActionResult Delete(
            [FromQuery] string login,
            [FromQuery] string password
        )
        {
            var response = _userService.Login(
                login: login,
                password: password
            );

            return Ok(
                response
            );
        }
    }
}