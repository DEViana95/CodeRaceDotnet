using BaseApi.Domain.Entities.Base;
using BaseApi.Domain.Entities.Enum;

namespace BaseApi.Domain.Entities
{
    public class Users : EntityBase
    {
        /// <summary>
        /// Login.
        /// </summary>
        /// <value></value>
        public virtual string Login { get; set; }

        /// <summary>
        /// Senha.
        /// </summary>
        /// <value></value>
        public virtual string Password { get; set;}

        /// <summary>
        /// Tipo de usuário.
        /// </summary>
        /// <value></value>
        public virtual UserTypeEnum Type { get; set; }
    }
}