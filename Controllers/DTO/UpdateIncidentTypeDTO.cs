namespace BaseApi.Controllers.DTO
{
    public class UpdateIncidentTypeDTO : CreateIncidentTypeDTO
    {
        public virtual long Id { get; set; }
    }
}