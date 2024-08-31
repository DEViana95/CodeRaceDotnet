using BaseApi.Domain.Entities.Base;

namespace BaseApi.Domain.Entities
{
    public class Cities : EntityBase
    {
        public virtual string Title { get; set; }
        public virtual decimal Lat { get; set; }
        public virtual decimal Lng { get; set;}
    }
}