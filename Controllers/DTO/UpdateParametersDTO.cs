namespace BaseApi.Controllers.DTO
{
    public class UpdateParametersDTO
    {
        public virtual long Id { get; set; }

        public virtual string Cellphone { get; set; }

        public virtual string Telegram { get; set; }
        
        public virtual string Phone { get; set; }
    }
}