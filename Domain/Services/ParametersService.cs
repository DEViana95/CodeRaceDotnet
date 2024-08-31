using System.Net;
using BaseApi.Controllers.DTO;
using BaseApi.Domain.Entities.Base;
using BaseApi.Domain.Services.Base;
using BaseApi.Infra.Data;

namespace BaseApi.Domain.Services
{
    public interface IParametersService : IServiceBase
    {
        ResponseData Get();

        ResponseData Update(
            UpdateParametersDTO dto
        );

        string GetPhone();
    }

    /// <summary>
    /// Classe de serviços de usuário.
    /// </summary>
    public class ParametersService : ServiceBase, IParametersService
    {
        private readonly AppDbContext _context;
        public ParametersService(
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
                var parameters = _context.Parameters
                    .Where(x => x.Id > 0)
                    .FirstOrDefault();

                if (parameters is null)
                    throw new Exception("Parametros não encontrado!");

                return response.ResponseSuccess(
                    response: parameters,
                    message: "Parametros buscados com sucesso!"
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

        public string GetPhone()
        {
            var parameters = _context.Parameters
                .Where(x => x.Id > 0)
                .FirstOrDefault();

            if (parameters is null)
                throw new Exception("Parametros não encontrado!");

            return parameters.Phone;
        }

        public ResponseData Update(UpdateParametersDTO dto)
        {
            var response = new ResponseData();
            try
            {
                if (dto is null)
                    throw new Exception("Dados inválidos.");

                var parameters = _context.Parameters
                    .Where(x => x.Id == dto.Id)
                    .FirstOrDefault();

                if (parameters is null)
                    throw new Exception("Parametros não encontrados!");

                if (!string.IsNullOrEmpty(dto.Cellphone) && dto.Cellphone != parameters.Cellphone)
                    parameters.Cellphone = dto.Cellphone;

                if (!string.IsNullOrEmpty(dto.Phone) && dto.Phone != parameters.Phone)
                    parameters.Phone = dto.Phone;

                if (dto.AdministratorId.HasValue && dto.AdministratorId != parameters.AdministratorId)
                    parameters.AdministratorId = dto.AdministratorId.Value;

                _context.Parameters.Update(parameters);

                var result = Commit(_context);

                if(result == default)
                    throw new Exception("Erro ao editar os parâmetros.");

                return response.ResponseSuccess(
                    message: "Parâmetros editados com sucesso!"
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