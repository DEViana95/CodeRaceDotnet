using System.Net;
using BaseApi.Controllers.DTO;
using BaseApi.Domain.Entities;
using BaseApi.Domain.Entities.Base;
using BaseApi.Domain.Entities.DTO;
using BaseApi.Domain.Services.Base;
using BaseApi.Infra.Data;

namespace BaseApi.Domain.Services
{
    public interface IReportDisasterService : IServiceBase
    {
        ResponseData Create(CreateReportDisasterDTO dto);

        ResponseData Update(
            long id,
            StatusEnum status
        );
    }

    public class ReportDisasterService : ServiceBase, IReportDisasterService
    {
        private readonly AppDbContext _context;
        private readonly IServiceProvider _service;
        public ReportDisasterService(
            AppDbContext context,
            IServiceProvider service
        )
        {
            _context = context;
            _service = service;
        }

        public ResponseData Create(
            CreateReportDisasterDTO dto
        )
        {
            var response = new ResponseData();
            try
            {
                var reportDisaster = new ReportDisaster
                {
                    Lat = dto.Lat,
                    Lng = dto.Lng,
                    TxId = dto.TxId,
                    Gravity = dto.Gravity,
                    Type = dto.Type,
                    Status = StatusEnum.ReceivedRegister,
                };

                 _context.ReportDisaster.Add(reportDisaster);

                var result = Commit(_context);

                var phone = _service.GetService<IParametersService>()
                    .GetPhone();

                if(result == default)
                    throw new Exception(
                        "Não foi possível registrar sua ocorrência, por favor tente mais tarde ou nos contate pelo número " + phone
                    );

                return response.ResponseSuccess(
                    message: "Registro realizado com sucesso!"
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

        public ResponseData Update(
            long id,
            StatusEnum status
        )
        {
            var response = new ResponseData();
            try
            {
                var domain = _context.ReportDisaster
                    .Where(x => x.Id == id)
                    .FirstOrDefault();

                if (domain is null)
                    throw new Exception("Registro não encontrado!");
                
                domain.Status = status;

                 _context.ReportDisaster.Update(domain);

                var result = Commit(_context);

                if(result == default)
                    throw new Exception(
                        "Erro ao atualizar status de registro."
                    );

                return response.ResponseSuccess(
                    message: "Status de registro atualizado com sucesso!"
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