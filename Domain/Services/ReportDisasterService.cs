using System.Net;
using BaseApi.Controllers.DTO;
using BaseApi.Domain.Entities;
using BaseApi.Domain.Entities.Base;
using BaseApi.Domain.Entities.DTO;
using BaseApi.Domain.Services.Base;
using BaseApi.Infra.Data;
using BaseApi.Tools;
using Microsoft.AspNetCore.SignalR;

namespace BaseApi.Domain.Services
{
    public interface IReportDisasterService : IServiceBase
    {
        ResponseData GetAll();

        ResponseData Create(CreateReportDisasterDTO dto);

        ResponseData Update(
            UpdateStatusReportDisasterDTO dto
        );
    }

    public class ReportDisasterService : ServiceBase, IReportDisasterService
    {
        private readonly AppDbContext _context;
        private readonly IServiceProvider _service;
        private readonly IHubContext<ChatHub> _hubContext;
        public ReportDisasterService(
            AppDbContext context,
            IServiceProvider service,
            IHubContext<ChatHub> hubContext
        )
        {
            _context = context;
            _service = service;
            _hubContext = hubContext;
        }

        public ResponseData GetAll()
        {
            var response = new ResponseData();
            try
            {
                var list = _context.ReportDisaster
                    .Select(x => new
                    {
                        x.Lat,
                        x.Lng,
                        x.CellphoneNumber,
                        x.TxId,
                        x.Gravity,
                        GravityDescription = x.Gravity.GetDescription(),
                        x.TypeId,
                        IncidentTypeDescription = x.Type.Title,
                        x.Status,
                        StatusDescription = x.Status.GetDescription(),
                        x.Created,
                        x.Finish,
                        x.Motive
                    })
                    .ToList();

                return response.ResponseSuccess(
                    response: list,
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
                    Gravity = (GravityEnum)dto.Gravity,
                    TypeId = dto.Type,
                    CellphoneNumber = dto.CellphoneNumber,
                    Status = StatusEnum.ReceivedRegister,
                    Created = DateTime.UtcNow
                };

                 _context.ReportDisaster.Add(reportDisaster);

                var result = Commit(_context);

                var phone = _service.GetService<IParametersService>()
                    .GetPhone();

                if(result == default)
                    throw new Exception(
                        "Não foi possível registrar sua ocorrência, por favor tente mais tarde ou nos contate pelo número " + phone
                    );

                Task.Run(()=>_hubContext.Clients.All.SendAsync("ReceiveMarkers", reportDisaster));

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
            UpdateStatusReportDisasterDTO dto
        )
        {
            var response = new ResponseData();
            try
            {
                var domain = _context.ReportDisaster
                    .Where(x => x.Id == dto.Id)
                    .FirstOrDefault();

                if (domain is null)
                    throw new Exception("Registro não encontrado!");

                if (dto.Status == StatusEnum.Cancelled)
                {
                    if (string.IsNullOrWhiteSpace(dto.Motive))
                        throw new Exception("É necessário informar um motivo quando um registro é cancelado.");

                    domain.Motive = dto.Motive;
                    domain.Finish = DateTime.UtcNow;
                }

                if (dto.Status == StatusEnum.Concluded)
                    domain.Finish = DateTime.UtcNow; 
                
                domain.Status = dto.Status;

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