namespace BaseApi.Controllers.DTO
{
    public class UpdateUserDTO : CreateUserDTO
    {
        public virtual long Id { get; set; }
    }
}