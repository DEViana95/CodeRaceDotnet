using BaseApi.Domain.Entities.DTO;

namespace BaseApi.Controllers.DTO
{
    public class UpdateStatusReportDisasterDTO
    {
        public virtual long Id { get; set; }
        public virtual StatusEnum Status { get; set; }
    }
}