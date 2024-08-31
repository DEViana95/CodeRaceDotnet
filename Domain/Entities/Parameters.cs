using BaseApi.Domain.Entities.Base;

namespace BaseApi.Domain.Entities
{
    public class Parameters : EntityBase
    {
        /// <summary>
        /// Título
        /// </summary>
        /// <value></value>
        public virtual string Cellphone { get; set; }

        /// <summary>
        /// Registro Ativo
        /// </summary>
        /// <value></value>
        public virtual long AdministratorId { get; set; }
    }
}