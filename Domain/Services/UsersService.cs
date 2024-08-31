using System.Net;
using BaseApi.Controllers.DTO;
using BaseApi.Domain.Entities;
using BaseApi.Domain.Entities.Base;
using BaseApi.Domain.Services.Base;
using BaseApi.Infra.Data;
using BaseApi.Tools;

namespace BaseApi.Domain.Services
{
    public interface IUsersService : IServiceBase
    {
        /// <summary>
        /// Busca os usuários páginados. 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        ResponseData GetAll(
            int skip,
            int take
        );

        /// <summary>
        /// Busca um usuário por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ResponseData Get(
            long id
        );

        /// <summary>
        /// Cria um usuário.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ResponseData Create(
            CreateUserDTO dto
        );

        /// <summary>
        /// Atualiza o usuário.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ResponseData Update(
            UpdateUserDTO dto
        );

        /// <summary>
        /// Deleta um usuário.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ResponseData Delete(
            long id
        );

        /// <summary>
        /// Acesso ao usuário.
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        ResponseData Login(
            string login,
            string password
        );
    }

    /// <summary>
    /// Classe de serviços de usuário.
    /// </summary>
    public class UsersService : ServiceBase, IUsersService
    {
        private readonly AppDbContext _context;
        public UsersService(
            AppDbContext context
        )
        {
            _context = context;
        }

        /// <summary>
        /// Busca os usuários páginados. 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public ResponseData GetAll(
            int skip,
            int take
        )
        {
            var response = new ResponseData();
            try
            {
                var result = _context.Users
                    .Skip(Tools.Tools.CalculateStartRow(skip, take)) 
                    .Take(take)
                    .ToList();

                return response.ResponseSuccess(
                    response: result,
                    message: "Usuários buscados com sucesso!"
                );
            }
            catch (Exception ex)
            {
                return response.ResponseError(
                    message: ex.Message,
                    statusCode: HttpStatusCode.BadRequest
                );
            }
        }

        /// <summary>
        /// Busca um usuário por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResponseData Get(
            long id
        )
        {
            var response = new ResponseData();
            try
            {
                if (id == default)
                    throw new Exception("Verificador inválido.");

                var user = _context.Users
                    .Where(x => x.Id == id)
                    .FirstOrDefault();

                if (user is null)
                    throw new Exception("Usuário não encontrado!");

                return response.ResponseSuccess(
                    response: user,
                    message: "Usuário buscado com sucesso!"
                );
            }
            catch (Exception ex)
            {
                return response.ResponseError(
                    message: ex.Message,
                    statusCode: HttpStatusCode.BadRequest
                );
            }
        }

        /// <summary>
        /// Cria um usuário.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ResponseData Create(
            CreateUserDTO dto
        )
        {
            var response = new ResponseData();
            try
            {
                if (dto is null)
                    throw new Exception("Dados inválidos.");

                var validateTxId = Tools.Tools.ValidateTxId(dto.Login);

                if (!validateTxId)
                    throw new Exception("CPF inválido.");

                var user = new Users
                {
                    Login = dto.Login,
                    Password = dto.Password,
                    Type = dto.Type
                };

                _context.Users.Add(user);

                var result = Commit(_context);

                if(result == default)
                    throw new Exception("Erro ao criar novo usuário.");

                return response.ResponseSuccess(
                    message: "Usuário criado com sucesso!"
                );
            }
            catch (Exception ex)
            {
                return response.ResponseError(
                    message: ex.Message,
                    statusCode: HttpStatusCode.BadRequest
                );
            }
        }

        /// <summary>
        /// Atualiza o usuário.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ResponseData Update(UpdateUserDTO dto)
        {
            var response = new ResponseData();
            try
            {
                if (dto is null)
                    throw new Exception("Dados inválidos.");

                var user = _context.Users
                    .Where(x => x.Id == dto.Id)
                    .FirstOrDefault();

                if (user is null)
                    throw new Exception("Usuário não encontrado!");

                var validateTxId = Tools.Tools.ValidateTxId(user.Login);

                if (!validateTxId)
                    throw new Exception("CPF inválido.");

                if (dto.Login != user.Login)
                    user.Login = dto.Login;

                if (dto.Password != user.Password)
                    user.Password = dto.Password;

                if (dto.Type != user.Type)
                    user.Type = dto.Type;

                _context.Users.Update(user);

                var result = Commit(_context);

                if(result == default)
                    throw new Exception("Erro ao editar usuário.");

                return response.ResponseSuccess(
                    message: "Usuário editado com sucesso!"
                );
            }
            catch (Exception ex)
            {
                return response.ResponseError(
                    message: ex.Message,
                    statusCode: HttpStatusCode.BadRequest
                );
            }
        }

        /// <summary>
        /// Deleta um usuário.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResponseData Delete(long id)
        {
            var response = new ResponseData();
            try
            {
                if (id == default)
                    throw new Exception("Verificador inválido.");
                    
                var user = _context.Users
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                
                if (user is null)
                    throw new Exception("Usuário não encontrado!");

                _context.Users.Remove(user);

                var result = Commit(_context);

                if(result == default)
                    throw new Exception("Erro ao excluir usuário.");

                return response.ResponseSuccess(
                    message: "Usuário excluído com sucesso!"
                );
            }
            catch (Exception ex)
            {
                return response.ResponseError(
                    message: ex.Message,
                    statusCode: HttpStatusCode.BadRequest
                );
            }
        }

        /// <summary>
        /// Acesso ao usuário.
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public ResponseData Login(
            string login,
            string password
        )
        {
            var response = new ResponseData();
            try
            {
                if (
                    string.IsNullOrWhiteSpace(login) ||
                    string.IsNullOrWhiteSpace(password)
                )
                    throw new Exception("Dados de login ou senha inválidos.");

                var validateTxId = Tools.Tools.ValidateTxId(login);

                if (!validateTxId)
                    throw new Exception("CPF inválido.");

                var user = _context.Users
                    .Where(x => 
                        x.Login == login &&
                        x.Password == password
                    )
                    .FirstOrDefault();

                if (user is null)
                    throw new Exception("Login ou senha estão incorretos.");

                return response.ResponseSuccess(
                    message: "Login efetuado com sucesso!"
                );
            }
            catch (Exception ex)
            {
                return response.ResponseError(
                    message: ex.Message,
                    statusCode: HttpStatusCode.BadRequest
                );
            }
        }
    }
}