namespace BaseApi.Controllers.DTO
{
    public class UpdateParametersDTO
    {
        public virtual long Id { get; set; }

        public virtual string Cellphone { get; set; }

        public virtual long? AdministratorId { get; set; }
        
        public virtual string Phone { get; set; }
    }
}