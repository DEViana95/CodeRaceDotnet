using BaseApi.Domain.Entities.Base;
using BaseApi.Domain.Entities.DTO;

namespace BaseApi.Domain.Entities
{
    public class ReportDisaster : EntityBase
    {
        public virtual decimal Lat { get; set; }
        public virtual decimal Lng { get; set; }
        public virtual string CellphoneNumber { get; set; }
        public virtual string TxId { get; set; }
        public virtual GravityEnum Gravity { get; set; }
        public virtual long Type { get; set; }
        public virtual StatusEnum Status { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime? Finish { get; set; }
        public virtual string Motive { get; set; }
    }
}