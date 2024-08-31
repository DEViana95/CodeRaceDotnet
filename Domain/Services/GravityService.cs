using System.ComponentModel;
using System.Net;
using System.Reflection;
using BaseApi.Controllers.DTO;
using BaseApi.Domain.Entities;
using BaseApi.Domain.Entities.Base;
using BaseApi.Domain.Entities.DTO;
using BaseApi.Domain.Services.Base;
using BaseApi.Infra.Data;
using BaseApi.Tools;

namespace BaseApi.Domain.Services
{
    public interface IGravityService
    { 
        ResponseData GetAllGravity();
    }

    /// <summary>
    /// Classe de serviços de usuário.
    /// </summary>
    public class GravityService : IGravityService
    {
        public GravityService()
        { }
        
        public ResponseData GetAllGravity()
        {
            var response = new ResponseData();
            try
            {
                var getGravitiesForSelect = Enum.GetValues(typeof(GravityEnum))
                    .Cast<GravityEnum>()
                    .Select(x => new
                    {
                        Value = x.ToString("D"),
                        Label = x.ToString()
                    })
                    .ToList();

                return response.ResponseSuccess(
                    response: getGravitiesForSelect,
                    message: "Níveis de gravidade buscados com sucesso!"
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