using System.Net;
using BaseApi.Controllers.DTO;
using BaseApi.Domain.Entities;
using BaseApi.Domain.Entities.Base;
using BaseApi.Domain.Services.Base;
using BaseApi.Infra.Data;
using BaseApi.Tools;

namespace BaseApi.Domain.Services
{
    public interface IIncidentTypesService : IServiceBase
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
            CreateIncidentTypeDTO dto
        );

        /// <summary>
        /// Atualiza o usuário.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ResponseData Update(
            UpdateIncidentTypeDTO dto
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

    /// <summary>
    /// Classe de serviços de usuário.
    /// </summary>
    public class IncidentTypesService : ServiceBase, IIncidentTypesService
    {
        private readonly AppDbContext _context;
        public IncidentTypesService(
            AppDbContext context
        )
        {
            _context = context;
        }

        /// <summary>
        /// Busca de desastres naturais paginado
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
                var result = _context.IncidentTypes
                    .Skip(PaginatedMethods.CalculateStartRow(skip, take)) 
                    .Take(take)
                    .ToList();

                return response.ResponseSuccess(
                    response: result,
                    message: "Tipos de desastres buscados com sucesso!"
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
        /// Busca um tipo de desastre natural por id.
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

                var incidentType = _context.IncidentTypes
                    .Where(x => x.Id == id)
                    .FirstOrDefault();

                if (incidentType is null)
                    throw new Exception("Usuário não encontrado!");

                return response.ResponseSuccess(
                    response: incidentType,
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
        /// Cria um tipo de desastre natural.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ResponseData Create(
            CreateIncidentTypeDTO dto
        )
        {
            var response = new ResponseData();
            try
            {
                if (dto is null)
                    throw new Exception("Dados inválidos.");

                var incidentType = new IncidentTypes
                {
                    Title = dto.Title,
                    Active = dto.Active
                };

                _context.IncidentTypes.Add(incidentType);

                var result = Commit(_context);

                if(result == default)
                    throw new Exception("Erro ao criar novo desastre natural.");

                return response.ResponseSuccess(
                    message: "Desastre natural criado com sucesso!"
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
        /// Atualiza o desastre natural.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ResponseData Update(UpdateIncidentTypeDTO dto)
        {
            var response = new ResponseData();
            try
            {
                if (dto is null)
                    throw new Exception("Dados inválidos.");

                var incidentType = _context.IncidentTypes
                    .Where(x => x.Id == dto.Id)
                    .FirstOrDefault();

                if (incidentType is null)
                    throw new Exception("Usuário não encontrado!");

                if (dto.Title != incidentType.Title)
                    incidentType.Title = dto.Title;

                if (dto.Active != incidentType.Active)
                    incidentType.Active = dto.Active;

                _context.IncidentTypes.Update(incidentType);

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
        /// Deleta um desastre natural.
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
                    
                var incidentType = _context.IncidentTypes
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                
                if (incidentType is null)
                    throw new Exception("Usuário não encontrado!");

                _context.IncidentTypes.Remove(incidentType);

                var result = Commit(_context);

                if(result == default)
                    throw new Exception("Erro ao excluir desastre natural.");

                return response.ResponseSuccess(
                    message: "Desastre natural excluído com sucesso!"
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