using System.Net;
using BaseApi.Domain.Entities.Base;
using BaseApi.Domain.Services.Base;
using BaseApi.Infra.Data;

namespace BaseApi.Domain.Services
{   
    public interface ICitiesService : IServiceBase
    {
        /// <summary>
        /// Busca todas as cidades.
        /// </summary>
        /// <returns></returns>
        ResponseData GetAllCities();
    }

    public class CitiesService : ServiceBase, ICitiesService
    {
        private readonly AppDbContext _context;
        public CitiesService(
            AppDbContext context
        )
        {
            _context = context;
        }

        /// <summary>
        /// Busca todas as cidades.
        /// </summary>
        /// <returns></returns>
        public ResponseData GetAllCities()
        {
            var response = new ResponseData();
            try
            {
                var cities = _context.Cities
                    .ToList();

                return response.ResponseSuccess(
                    response: cities,
                    message: "Cidades buscadas com sucesso!"
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