using System.Net;
using BaseApi.Domain.Entities.Base;
using BaseApi.Infra.Data;

namespace BaseApi.Domain.Services
{
    public interface IUsersService
    {
        ResponseData Get();
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

        public ResponseData Get()
        {
            var response = new ResponseData();
            try
            {
                var teste = _context.Users.ToList();

                return response.ResponseSuccess(
                    response: teste,
                    message: "Requisição realizada com sucesso"
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