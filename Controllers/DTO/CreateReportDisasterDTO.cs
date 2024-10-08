using BaseApi.Domain.Entities.DTO;

namespace BaseApi.Controllers.DTO
{
    public class CreateReportDisasterDTO
    {
        public virtual decimal Lat { get; set; }
        public virtual decimal Lng { get; set; }
        public virtual string TxId { get; set; }
        public virtual long Gravity { get; set; }
        public virtual long Type { get; set; }
        public virtual string CellphoneNumber { get; set; }

    }
}