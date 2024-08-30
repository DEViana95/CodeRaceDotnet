using System.Net;
using BaseApi.Controllers.DTO;
using BaseApi.Domain.Entities;
using BaseApi.Domain.Entities.Base;
using BaseApi.Infra.Data;
using BaseApi.Tools;

namespace BaseApi.Domain.Services
{
    public interface IUsersService
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
    }

    public class UsersService : IUsersService
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
                    .Skip(PaginatedMethods.CalculateStartRow(skip, take)) 
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

                var user = new Users
                {
                    Login = dto.Login,
                    Password = dto.Password,
                    Type = dto.Type
                };

                _context.Users.Add(user);

                var result = _context.SaveChanges();

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

                if (dto.Login != user.Login)
                    user.Login = dto.Login;

                if (dto.Password != user.Password)
                    user.Password = dto.Password;

                if (dto.Type != user.Type)
                    user.Type = dto.Type;

                _context.Users.Update(user);

                var result = _context.SaveChanges();

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

                var result = _context.SaveChanges();

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
    }
}