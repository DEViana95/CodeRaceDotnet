using BaseApi.Domain.Entities.Enum;

namespace BaseApi.Controllers.DTO
{
    public class CreateUserDTO
    {
        public virtual string Login { get; set; }
        public virtual string Password { get; set; }
        public virtual UserTypeEnum Type { get; set; }
    }
}